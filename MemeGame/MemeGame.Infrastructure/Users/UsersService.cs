using MemeGame.Application.Users;
using MemeGame.Domain.Users.Dto;

namespace MemeGame.Infrastructure.Users
{
    public class UsersService : IUserService
    {
        private Dictionary<string, UserDto> _users { get; set; } = new Dictionary<string, UserDto>();

        public UserDto[] GetLobbyUsers()
        {
            return _users.Values.Where(u => !u.IsInGame).ToArray();
        }

        public string[] GetLobbyUsersConnections()
        {
            return _users.Where(u => !u.Value.IsInGame).Select(g => g.Key).ToArray();
        }

        public void Login(string connectionId, string name)
        {
            _users.Add(connectionId, new UserDto { Name = name });
        }

        public void SetInGame(string userId)
        {
            if (!_users.TryGetValue(userId, out var user))
            {
                throw new Exception("Пользователя не существует");
            }

            user.IsInGame = true;
        }
    }
}
