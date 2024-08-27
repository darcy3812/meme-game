using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MemeGame.Domain.Games.Dto
{
    public class GameSettingsDto : IValidatableObject
    {
        public const int MinPlayers = 3;

        public const int MinSecondsToAnswer = 5;
        public int MaxPlayers { get; set; }
        public int SecondsToAnswer { get; set; }
        public EndGameCondition EndGameCondition { get; set; }
        public int? MaxRounds { get; set; }
        public int? MaxPoints { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MaxPlayers < MinPlayers)
            {
                throw new ValidationException(nameof(MaxPlayers));
            }
            if (SecondsToAnswer < MinSecondsToAnswer)
            {
                throw new ValidationException(nameof(SecondsToAnswer));
            }

            if (EndGameCondition == EndGameCondition.ByPoints && MaxPoints <= 0)
            {
                throw new ValidationException(nameof(MaxPoints));
            }

            if (EndGameCondition == EndGameCondition.ByRounds && MaxRounds <= 0)
            {
                throw new ValidationException(nameof(MaxRounds));
            }

            if (EndGameCondition == EndGameCondition.ByRounds && MaxPoints !=null)
            {
                throw new ValidationException(nameof(MaxPoints));
            }
            if (EndGameCondition == EndGameCondition.ByPoints && MaxRounds != null)
            {
                throw new ValidationException(nameof(MaxRounds));
            }

            yield return ValidationResult.Success;
        }
    }
}
