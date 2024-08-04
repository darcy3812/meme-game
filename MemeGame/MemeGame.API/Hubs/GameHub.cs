using MemeGame.Application.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MemeGame.API.Hubs
{
    [Authorize]
    public class GameHub : Hub
    {
        private readonly IGameService _gameService;

        public GameHub(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async override Task OnConnectedAsync()
        {
            var gameId = await _gameService.GetCurrentGameId();
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());
        }
    }
}
