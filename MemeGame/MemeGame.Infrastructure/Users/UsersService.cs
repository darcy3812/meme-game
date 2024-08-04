using MemeGame.Application.Users;
using MemeGame.Domain.Users;
using MemeGame.Domain.Users.Dto;
using MemeGame.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;

namespace MemeGame.Infrastructure.Users
{
    public class UsersService : IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public UsersService(ApplicationContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        private Dictionary<string, UserDto> _users { get; set; } = new Dictionary<string, UserDto>();

        public UserDto[] GetLobbyUsers()
        {
            return _users.Values.Where(u => !u.IsInGame).ToArray();
        }

        public string[] GetLobbyUsersConnections()
        {
            return _users.Where(u => !u.Value.IsInGame).Select(g => g.Key).ToArray();
        }

        public async Task<int> SignIn(LoginDto loginDto)
        {
            //_users.Add(connectionId, new UserDto { Name = name });
            var user = new User
            {
                Name = loginDto.Name
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public void SetInGame(string userId)
        {
            if (!_users.TryGetValue(userId, out var user))
            {
                throw new Exception("Пользователя не существует");
            }

            user.IsInGame = true;
        }

        public void GetCurrentUser()
        {
            _httpContext.HttpContext.User.
        }
    }
}
