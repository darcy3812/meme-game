using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Dto;

namespace MemeGame.Domain.Games.Notifications
{
    public class GameCreatedNotification : INotification
    {
        public GameCreatedNotification(GameCreatedDto gameCreatedDto)
        {
            Game = gameCreatedDto;
        }

        public GameCreatedDto Game { get; set; }
    }
}
