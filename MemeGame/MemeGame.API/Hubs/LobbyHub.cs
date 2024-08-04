using MemeGame.Application.Games;
using MemeGame.Domain.Games.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MemeGame.API.Hubs
{
    [Authorize]
    public class LobbyHub : Hub
    {
        private readonly IGameService _gameService;

        public LobbyHub(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async override Task OnConnectedAsync()
        {
            await _gameService.GetGamesAsync();
        }

        public async Task<GameDto> CreateGame(GameCreatedDto gameCreatedDto)
        {
            return await _gameService.CreateGameAsync(gameCreatedDto);
        }

        public async Task<GameDto> JoinGame(int id)
        {
            return await _gameService.JoinGameAsync(id);
        }
    }
}
