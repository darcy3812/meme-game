using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Notifications;
using MemeGame.Domain.Users;
using MemeGame.Domain.Users.Dto;
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

        public void SendNotification<TNotification>(TNotification notification) where TNotification : INotification
        {
            if (notification is IInGameNotification gameNotification)
            {
                _hub.Clients.Group(gameNotification.GameId).SendAsync(notification.GetType().Name, notification);

                return;
            }

            var lobbyUsers = GetLobbyUsersConnections();
            _hub.Clients.Clients(lobbyUsers).SendAsync(notification.GetType().Name, notification);
        }        

        private string[] GetLobbyUsersConnections()
        {
            return UsersService.Users
                .Where(u => !u.Value.IsInGame)
                .Select(u => u.Key)
                .ToArray();
        }
    }
}
