using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Dto;

namespace MemeGame.Domain.Games.Notifications
{
    public class GameUpdatedNotification : IInGameNotification
    {
        public GameUpdatedNotification(GameDto gameDto, int gameId)
        {
            Game = gameDto;
            GameId = gameId;
        }

        public GameDto Game { get; set; }
        public int GameId { get; set; }
    }
}
