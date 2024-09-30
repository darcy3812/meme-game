using MemeGame.Common.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Domain.GameUsers.Notifications
{
    public class PlayerLeaveNotification : IInGameNotification
    {
        public PlayerLeaveNotification(int gamerUserId, int gameId)
        {
            GamerUserId = gamerUserId;
            GameId = gameId;
        }
        public int GamerUserId { get; set; }
        public int GameId { get; set; }

    }
}
