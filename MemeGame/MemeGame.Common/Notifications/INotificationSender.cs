namespace MemeGame.Common.Notifications
{
    public interface INotificationSender
    {
        void SendNotification<TNotification>(TNotification notification) where TNotification : INotification;
    }
}
