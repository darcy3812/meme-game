using MemeGame.Domain.GameUsers.Dto;
using System.Collections.Generic;

namespace MemeGame.Domain.Games.Dto
{
    public class GameDto
    {
        public string Name { get; set; }
        public List<GameUserDto> GameUsers { get; set; }
        public GameSettingsDto GameSettings { get; set; }        
    }
}
