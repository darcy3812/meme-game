using MemeGame.Domain.Games.Dto;

namespace MemeGame.Application.Games
{
    public interface IGameService
    {
        Task<GameCreatedDto> CreateGameAsync(GameCreatedDto gameCreatedDto);
        Task<List<GameListItemDto>> GetGamesAsync();
        Task DeleteGameAsync(int id);
        Task JoinGameAsync(int id);
    }
}
