namespace MemeGame.Common.Notifications
{
    public interface ITargetNotification : INotification
    {
        public int UserId { get; set; }
    }
}
