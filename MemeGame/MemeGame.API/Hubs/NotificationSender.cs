using MemeGame.Common.Notifications;
using MemeGame.Infrastructure.Users;
using Microsoft.AspNetCore.SignalR;
using System.Linq;

namespace MemeGame.API.Hubs
{
    public class NotificationSender : INotificationSender
    {
        private readonly IHubContext<GameHub> _hub;

        public NotificationSender(IHubContext<GameHub> hub)
        {
            _hub = hub;
        }

        public void SendNotificationInGame<TNotification>(TNotification notification) where TNotification : IInGameNotification
        {
            _hub.Clients.Group(notification.GameId).SendAsync(notification.GetType().Name, notification);
        }

        public void SendNotificationInLobby<TNotification>(TNotification notification) where TNotification : IInLobbyNotification
        {
            var users = UsersService.Users
                .Where(u => !u.Value.IsInGame)
                .Select(u => u.Key)
                .ToList();

            _hub.Clients.Clients(users).SendAsync(notification.GetType().Name, notification);
        }
    }
}
