using MemeGame.Application.Games;
using MemeGame.Application.Games.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemeGame.API.Controllers
{
    [ApiController]
    public class GamesController
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
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
