using Mapster;
using MemeGame.Application.Games;
using MemeGame.Application.Notifications;
using MemeGame.Application.UsersInfo;
using MemeGame.Common.Extensions;
using MemeGame.Domain;
using MemeGame.Domain.Games;
using MemeGame.Domain.Games.Dto;
using MemeGame.Domain.Games.Notifications;
using MemeGame.Domain.GameUsers;
using MemeGame.Domain.GameUsers.Notifications;
using MemeGame.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemeGame.Infrastructure.Games
{
    public class GameService : IGameService
    {
        private readonly ApplicationContext _context;
        private readonly ILobbyNotificationSender _lobbyNotificationSender;
        private readonly IGameNotificationSender _gameNotificationSender;
        private readonly IUserInfo _userInfo;

        private const int PageSize = 10;

        public GameService(
            ApplicationContext context,
            ILobbyNotificationSender lobbyNotificationSender,
            IGameNotificationSender gameNotificationSender,
            IUserInfo userInfo
            )
        {
            _context = context;
            _lobbyNotificationSender = lobbyNotificationSender;
            _gameNotificationSender = gameNotificationSender;
            _userInfo = userInfo;
        }

        public async Task<GameDto> CreateGameAsync(GameCreatedDto gameCreatedDto)
        {
            gameCreatedDto.Validate();

            var game = gameCreatedDto.Adapt<Game>();

            game.GameUsers.Add(new GameUser
            {
                UserId = _userInfo.GetCurrentUserId(),
            });

            game.AuthorId = _userInfo.GetCurrentUserId();

            _context.Games.Add(game);

            await _context.SaveChangesAsync();

            gameCreatedDto = game.Adapt<GameCreatedDto>();

            _lobbyNotificationSender.SendNotification(new GameCreatedNotification(gameCreatedDto));

            return game.Adapt<GameDto>();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            {
                throw new Exception("Игра не найдена");
            }

            if (_userInfo.GetCurrentUserId() != game.AuthorId)
            {
                throw new Exception("Только создатель игры может её удалить");
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            _lobbyNotificationSender.SendNotification(new GameDeletedNotification(id));
        }

        public async Task<int> GetCurrentGameId()
        {
            var userId = _userInfo.GetCurrentUserId();
            var gameId = await _context.Games
                .Where(g => g.GameStatus != GameStatus.Finished && g.GameUsers
                    .Any(gu => gu.UserId == userId))
                .Select(g => g.Id)
                .SingleOrDefaultAsync();

            return gameId;
        }

        public async Task<List<GameListItemDto>> GetGamesAsync()
        {
            var games = await _context.Games
                .Include(g => g.GameUsers)
                .OrderByDescending(g => g.CreationDate)
                .Take(PageSize)
                .ProjectToType<GameListItemDto>()
                .ToListAsync();

            var gameListNotification = new GameListNotification(games);
            _lobbyNotificationSender.SendNotification(gameListNotification);

            return games;
        }

        public async Task<GameDto> JoinGameAsync(int id)
        {
            var game = await _context.Games.Where(g => g.Id == id && g.GameStatus == GameStatus.Queue).FirstOrDefaultAsync();

            if (game == null)
            {
                throw new Exception("Игра не найдена");
            }

            game.GameUsers.Add(new GameUser
            {
                UserId = _userInfo.GetCurrentUserId()
            });

            await _context.SaveChangesAsync();

            var gameListItemDto = game.Adapt<GameListItemDto>();
            var gameDto = game.Adapt<GameDto>();

            _lobbyNotificationSender.SendNotification(new GameListItemUpdatedNotification(gameListItemDto));
            _lobbyNotificationSender.SendNotification(new GameUpdatedNotification(gameDto, game.Id));

            return gameDto;
        }

        public async Task ChangeGameSettingsAsync(int id, GameSettingsDto gameSettingsDto)
        {
            gameSettingsDto.Validate();

            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game == null)
            {
                throw new Exception("Игра не найдена");
            }

            if (_userInfo.GetCurrentUserId() != game.AuthorId)
            {
                throw new Exception("Только создатель игры может изменять её настройки");
            }

            if (game.GameStatus != GameStatus.Queue)
            {
                throw new Exception("Изменить настройки можно только до начала игры");
            }

            if (game.GameUsers.Count > gameSettingsDto.MaxPlayers)
            {
                throw new Exception("В игре уже слишком много игроков");
            }

            game.GameSettings = gameSettingsDto.Adapt<GameSetting>();

            game.GameSettings.Id = game.GameSettingsId;

            await _context.SaveChangesAsync();

            _lobbyNotificationSender.SendNotification(new GameSettingsUpdatedNotificationForLobby(gameSettingsDto, id));
            _gameNotificationSender.SendNotification(new GameSettingsUpdatedNotification(gameSettingsDto, id));
        }

        public async Task KickPlayer(int gameUserId, int gameId)
        {
            var game = await _context.Games.Include(_ => _.GameUsers).FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                throw new Exception("Игра не найдена");
            }

            if (_userInfo.GetCurrentUserId() != game.AuthorId)
            {
                throw new Exception("Только создатель игры может кикать игроков");
            }
            GameUser gameUser = game.GameUsers.FirstOrDefault(g => g.Id == gameUserId);

            if (gameUser == null)
            {
                throw new Exception("В игре нет такого игрока");
            }

            _context.GameUsers.Remove(gameUser);

            await _context.SaveChangesAsync();

            _gameNotificationSender.SendNotification(new GameUserKickedNotification(gameUserId, gameId));
            _lobbyNotificationSender.SendNotification(new GameUserKickedNotification(gameUserId, gameId));

        }

        public async Task LeaveGame()
        {
            int currentUserId = _userInfo.GetCurrentUserId();

            GameUser gameUser = _context.GameUsers.Where(_ => _.User.Id == currentUserId).FirstOrDefault(_ => _.Game.GameStatus != GameStatus.Finished);

            _context.GameUsers.Remove(gameUser);

            await _context.SaveChangesAsync();

            _gameNotificationSender.SendNotification(new PlayerLeaveNotification(gameUser.Id, gameUser.GameId));                     

        }
    }
}