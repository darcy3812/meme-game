using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Dto;

namespace MemeGame.Domain.Games.Notifications
{
    public class GameListItemUpdatedNotification : INotification
    {
        public GameListItemUpdatedNotification(GameListItemDto gameDto)
        {
            Game = gameDto;
        }
        public GameListItemDto Game { get; set; }
    }
}
