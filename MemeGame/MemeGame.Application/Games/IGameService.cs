using MemeGame.Domain.Games.Dto;

namespace MemeGame.Application.Games
{
    public interface IGameService
    {
        Task<GameDto> CreateGameAsync(GameCreatedDto gameCreatedDto);
        Task<List<GameListItemDto>> GetGamesAsync();
        Task DeleteGameAsync(int id);
        Task<GameDto> JoinGameAsync(int id);
        Task<int> GetCurrentGameId();
        Task ChangeGameSettingsAsync(int id, GameSettingsDto gameSettingsDto);
        Task KickPlayer(int userId, int gameId);
    }
}
