using MemeGame.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MemeGame.API.Hubs
{
    [Authorize]
    public class GameHub : Hub
    {
        private readonly IUserService _userService;

        public GameHub(IUserService userService)
        {
            _userService = userService;
        }
        public override Task OnConnectedAsync()
        {            
            return base.OnConnectedAsync();            
        }

        public Task Test()
        {
            return Task.CompletedTask;
        }
    }
}
