using System.ComponentModel.DataAnnotations;

namespace MemeGame.Domain.Games.Dto
{
    public class GameCreatedDto
    {
        
        public string Name { get; set; }

        
        public GameSettingsDto GameSettings { get; set; }
    }
}