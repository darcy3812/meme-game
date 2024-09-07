using MemeGame.Common.Notifications;
using MemeGame.Domain.Games.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Domain.Games.Notifications
{
    public class GameSettingsUpdatedNotificationForLobby : INotification
    {
        public GameSettingsUpdatedNotificationForLobby(GameSettingsDto gameSettingDto, int gameId)
        {
            GameSettings = gameSettingDto;
            GameId = gameId;
        }

        public GameSettingsDto GameSettings { get; set; }
        public int GameId { get; set; }

    }
}