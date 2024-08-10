using MemeGame.Application.Users;
using MemeGame.Domain.Users;
using MemeGame.Domain.Users.Dto;
using MemeGame.Infrastructure.Persistance;
using System.Threading.Tasks;

namespace MemeGame.Infrastructure.Users
{
    public class UsersService : IUserService
    {
        private readonly ApplicationContext _context;

        public UsersService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> SignIn(LoginDto loginDto)
        {
            var user = new User
            {
                Name = loginDto.Name
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
