using MemeGame.Domain.Users.Dto;

namespace MemeGame.Application.Users
{
    public interface IUserService
    {
        Task<int> SignIn(LoginDto loginDto);
        void SetInGame(string userId);
        UserDto[] GetLobbyUsers();
        string[] GetLobbyUsersConnections();
    }
}
