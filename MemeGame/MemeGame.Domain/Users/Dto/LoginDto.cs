using System.ComponentModel.DataAnnotations;

namespace MemeGame.Domain.Users.Dto
{
    public class LoginDto
    {
        [Required]
        public string Name { get; set; }
    }
}
