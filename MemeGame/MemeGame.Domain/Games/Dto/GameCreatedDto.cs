using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MemeGame.Domain.Games.Dto
{
    public class GameCreatedDto : IValidatableObject
    {
        public const int MinNameLength = 5;

        public string Name { get; set; }

        public GameSettingsDto GameSettings { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length < MinNameLength)
            {
                throw new ValidationException(nameof(Name));
            }

            yield return ValidationResult.Success;
        }
    }
}