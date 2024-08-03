using MemeGame.Application.Users;
using MemeGame.Common.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace MemeGame.API.Hubs
{
    public class NotificationSender : INotificationSender
    {
        private readonly IHubContext<GameHub> _hub;
        private readonly IUserService _userService;

        public NotificationSender(IHubContext<GameHub> hub, IUserService userService)
        {
            _hub = hub;
            _userService = userService;
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
            return _userService.GetLobbyUsersConnections();
        }
    }
}
