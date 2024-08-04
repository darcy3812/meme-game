using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Dto;
using System.Collections.Generic;

namespace MemeGame.Domain.Games.Notifications
{
    public class GameListNotification : ICurrentUserNotification
    {
        public GameListNotification(List<GameListItemDto> games)
        {
            Games = games;
        }

        public List<GameListItemDto> Games { get; }
    }
}
