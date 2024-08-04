namespace MemeGame.Common.Notifications
{
    public interface IInGameNotification : INotification
    {
        public int GameId { get; set; }
    }
}
