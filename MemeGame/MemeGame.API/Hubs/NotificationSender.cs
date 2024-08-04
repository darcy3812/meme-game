using MemeGame.Application.Users;
using MemeGame.Application.UsersInfo;
using MemeGame.Common.Notifications;
using Microsoft.AspNetCore.SignalR;
using System;

namespace MemeGame.API.Hubs
{
    public class NotificationSender<THub> : INotificationSender<THub> where THub : Hub
    {
        private readonly IHubContext<THub> _hub;
        private readonly IUserInfo _userInfo;

        public NotificationSender(IHubContext<THub> hub, IUserInfo userInfo)
        {
            _hub = hub;
            _userInfo = userInfo;
        }

        public void SendNotification<TNotification>(TNotification notification) where TNotification : INotification
        {
            var target = GetTargetClients(notification);
            target.SendAsync(notification.GetType().Name, notification);
        }

        private IClientProxy GetTargetClients<TNotification>(TNotification notification) where TNotification : INotification
        {
            switch (notification)
            {
                case IInGameNotification notify:
                    return _hub.Clients.Group(notify.GameId.ToString());
                case ICurrentUserNotification:
                    var currentUserId = _userInfo.GetCurrentUserId();
                    return _hub.Clients.User(currentUserId.ToString());
                case ITargetNotification notify:
                    return _hub.Clients.User(notify.UserId.ToString());
                case INotification:
                    return _hub.Clients.All;
                default:
                    throw new Exception("Unknown notification type");
            }
        }
    }
}
