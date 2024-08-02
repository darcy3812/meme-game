using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MemeGame.API.Hubs
{
    public class GameHub : Hub
    {

        public async Task Login(string name)
        {
            //UsersService.Users.Add(Context.ConnectionId, new UserDto
            //{
            //    Name = name
            //});
        }        
    }
}
