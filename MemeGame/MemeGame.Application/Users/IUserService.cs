namespace MemeGame.Application.Users
{
    public interface IUserService
    {
        Task Login(string username);
    }
}
