using Mapster;
using MemeGame.Application.Games;
using MemeGame.Application.Notifications;
using MemeGame.Application.UsersInfo;
using MemeGame.Common.Extensions;
using MemeGame.Domain.Games;
using MemeGame.Domain.Games.Dto;
using MemeGame.Domain.Games.Notifications;
using MemeGame.Domain.GameUsers;
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
        private readonly IUserInfo _userInfo;

        private const int PageSize = 10;

        public GameService(
            ApplicationContext context,
            ILobbyNotificationSender lobbyNotificationSender,
            IUserInfo userInfo
            )
        {
            _context = context;
            _lobbyNotificationSender = lobbyNotificationSender;
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

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            _lobbyNotificationSender.SendNotification(new GameDeletedNotification(id));
        }

        public async Task<int> GetCurrentGameId()
        {
            var userId = _userInfo.GetCurrentUserId();
            var gameId = await _context.Games
                .Where(g => !g.IsFinished && g.GameUsers
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
            var game = await _context.Games.Where(g => g.Id == id && !g.IsFinished).FirstOrDefaultAsync();

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
    }
}