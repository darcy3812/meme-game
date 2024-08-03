using MemeGame.API.Hubs;
using MemeGame.Application.Games;
using MemeGame.Domain.Games.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemeGame.API.Controllers
{
    [ApiController]
    [Authorize]
    public class GamesController
    {
        private readonly IGameService _gameService;
        private readonly IHubContext<GameHub> _gameHub;

        public GamesController(IGameService gameService, IHubContext<GameHub> gameHub)
        {
            _gameService = gameService;
            _gameHub = gameHub;
        }

        [HttpPost("api/Games")]
        public async Task CreateGameAsync([FromBody] GameCreatedDto gameCreatedDto)
        {
            await _gameService.CreateGameAsync(gameCreatedDto);            
        }

        [HttpGet("api/Games")]
        public async Task<List<GameListItemDto>> GetGamesAsync()
        {
            return await _gameService.GetGamesAsync();
        }


    }
}
