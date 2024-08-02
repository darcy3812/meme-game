using MemeGame.Application.Games.Dto;
using MemeGame.Common.Notifications;

namespace MemeGame.Domain.Games.Notifications
{
    public class GameCreatedNotification : IInLobbyNotification
    {
        public GameCreatedNotification(GameCreatedDto gameCreatedDto)
        {
            Game = gameCreatedDto;
        }

        public GameCreatedDto Game { get; set; }
    }
}
