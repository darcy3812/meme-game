using MemeGame.Application.Users;
using MemeGame.Domain.Users.Dto;

namespace MemeGame.Infrastructure.Users
{
    public class UsersService : IUserService
    {
        public UsersService()
        {
            
        }
        public static Dictionary<string, UserDto> Users { get; set; } = new Dictionary<string, UserDto>();


        public Task Login(string username)
        {
            throw new NotImplementedException();
        }
    }
}
