using System.ComponentModel.DataAnnotations;

namespace MemeGame.Domain.Games.Dto
{
    public class GameCreatedDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public GameSettingsDto GameSettings { get; set; }
    }
}