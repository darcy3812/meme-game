using MemeGame.Application.Games.Dto;
using MemeGame.Domain.Users.Dto;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeGame.API.Hubs
{
    public class GameHub : Hub
    {
        public static Dictionary<string, UserDto> Users { get; set; } = new Dictionary<string, UserDto>();

        public async Task LoginAsync(string name)
        {
            Users.Add(Context.ConnectionId, new UserDto
            {
                ConnectionId = Context.ConnectionId
            });
        }

        public async Task NotifyGameCreated(GameListItemDto gameDto)
        {
            var users = Users.Where(_ => !_.Value.IsInGame).Select(u => u.Key);
            await Clients.Clients(users).SendAsync("GameCreated", gameDto);
        }
    }
}
