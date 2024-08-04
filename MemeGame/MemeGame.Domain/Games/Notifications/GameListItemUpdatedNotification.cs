using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
