using MemeGame.Common.Notifications;

namespace MemeGame.Domain.Games.Notifications
{
    public class GameDeletedNotification : INotification
    {
        public GameDeletedNotification(int gameId)
        {
            Id = gameId;
        }

        public int Id { get; set; }
    }
}
