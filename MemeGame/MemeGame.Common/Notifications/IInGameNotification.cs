namespace MemeGame.Common.Notifications
{
    public interface IInGameNotification : INotification
    {
        public string GameId { get; set; }
    }
}
