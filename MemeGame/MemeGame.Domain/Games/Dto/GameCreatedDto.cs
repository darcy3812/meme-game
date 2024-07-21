using MemeGame.Domain.Games.Dto;
using System.ComponentModel.DataAnnotations;

namespace MemeGame.Application.Games.Dto
{
    public class GameCreatedDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public GameSettingsDto GameSettings { get; set; }
    }
}