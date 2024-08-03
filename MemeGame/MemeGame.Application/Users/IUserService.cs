using MemeGame.Domain.Users.Dto;

namespace MemeGame.Application.Users
{
    public interface IUserService
    {
        void Login(string userId, string name);
        void SetInGame(string userId);
        UserDto[] GetLobbyUsers();
        string[] GetLobbyUsersConnections();
    }
}
