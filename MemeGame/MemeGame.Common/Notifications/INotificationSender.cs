namespace MemeGame.Common.Notifications
{
    public interface INotificationSender
    {
        void SendNotificationInGame<TNotification>(TNotification notification) where TNotification : IInGameNotification;
        void SendNotificationInLobby<TNotification>(TNotification notification) where TNotification : IInLobbyNotification;
    }
}
