using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Domain.GameUsers.Notifications
{
    public class GameUserKickedNotification : IInGameNotification
    {
        public GameUserKickedNotification(int gamerUserId, int gameId)
        {
            GamerUserId = gamerUserId;
            GameId = gameId;
        }

        public int GamerUserId { get; set; }
        public int GameId { get; set; }

    }
}
