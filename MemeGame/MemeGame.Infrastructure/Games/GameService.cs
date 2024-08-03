using Mapster;
using MemeGame.Application.Games;
using MemeGame.Common.Notifications;
using MemeGame.Domain.Games;
using MemeGame.Domain.Games.Dto;
using MemeGame.Domain.Games.Notifications;
using MemeGame.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MemeGame.Infrastructure.Games
{
    public class GameService : IGameService
    {
        private readonly ApplicationContext _context;
        private readonly INotificationSender _notificationSender;

        public GameService(ApplicationContext context, INotificationSender notificationSender)
        {
            _context = context;
            _notificationSender = notificationSender;
        }

        public async Task<GameCreatedDto> CreateGameAsync(GameCreatedDto gameCreatedDto)
        {
            var game = gameCreatedDto.Adapt<Game>();

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            gameCreatedDto = game.Adapt<GameCreatedDto>();
            _notificationSender.SendNotification(new GameCreatedNotification(gameCreatedDto));

            return gameCreatedDto;
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

            _notificationSender.SendNotification(new GameDeletedNotification(id));
        }

        public async Task<List<GameListItemDto>> GetGamesAsync()
        {
            return await _context.Games
                .OrderByDescending(g => g.CreationDate)
                .ProjectToType<GameListItemDto>()
                .ToListAsync();
        }

        public async Task JoinGameAsync(int id)
        {
            //var game = _context.Games.Where(g => g.Id == id && !g.IsFinished)
            //    .ProjectToType<>
        }
    }
}