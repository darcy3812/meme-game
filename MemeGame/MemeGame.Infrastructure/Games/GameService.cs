using Mapster;
using MemeGame.Application.Games;
using MemeGame.Application.Games.Dto;
using MemeGame.Domain.Games;
using MemeGame.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MemeGame.Infrastructure.Games
{
    public class GameService : IGameService
    {
        private readonly ApplicationContext _context;

        public GameService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<GameCreatedDto> CreateGameAsync(GameCreatedDto gameCreatedDto)
        {
            var game = gameCreatedDto.Adapt<Game>();

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game.Adapt<GameCreatedDto>();
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
            throw new NotImplementedException();
        }
    }
}
