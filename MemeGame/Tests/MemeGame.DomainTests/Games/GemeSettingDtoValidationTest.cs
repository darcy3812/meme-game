using MemeGame.Common.Extensions;
using MemeGame.Domain;
using MemeGame.Domain.Games.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.DomainTests.Games
{
    [TestFixture]
    public class GemeSettingDtoValidationTest
    {
        [TestCase(2)]
        public void InvalidMaxPlayer_ShouldThrowException(int maxPlayers)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = maxPlayers,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = null,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(3)]
        [TestCase(10)]
        public void ValidMaxPlayer_ShouldNotThrowException(int maxPlayers)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = maxPlayers,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = null,
                MaxPoints = 5
            };

            // Act
            dto.Validate();
        }

        [TestCase(2)]
        public void InvalidSecondsToAnswer_ShouldThrowException(int secondsToAnswer)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = secondsToAnswer,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = null,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(5)]
        [TestCase(10)]
        public void ValidSecondsToAnswer_ShouldNotThrowException(int secondsToAnswer)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = secondsToAnswer,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = null,
                MaxPoints = 5
            };

            // Act
            dto.Validate();
        }


        [TestCase(0)]
        public void InvalidMaxRounds_ShouldThrowException(int maxRounds)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByRounds,
                MaxRounds = maxRounds,
                MaxPoints = null
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(2)]
        [TestCase(10)]
        public void ValidMaxRounds_ShouldNotThrowException(int maxRounds)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByRounds,
                MaxRounds = maxRounds,
                MaxPoints = null
            };

            // Act
            dto.Validate();
        }

        [TestCase(0)]
        public void InvalidMaxPoints_ShouldThrowException(int maxPoints)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = null,
                MaxPoints = maxPoints
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(2)]
        [TestCase(10)]
        public void ValidMaxPoints_ShouldNotThrowException(int maxPoints)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = null,
                MaxPoints = maxPoints
            };

            // Act
            dto.Validate();
        }

        [TestCase(EndGameCondition.ByRounds, 5, 5)]
        [TestCase(EndGameCondition.ByPoints, 5, 5)]
        public void EndGameConditionValidation_ShouldThrowException(EndGameCondition endGameCondition, int? maxRounds, int? maxPoints)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = endGameCondition,
                MaxRounds = maxRounds,
                MaxPoints = maxPoints
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(EndGameCondition.ByRounds, 5, null)]
        [TestCase(EndGameCondition.ByPoints, null, 5)]
        public void EndGameConditionValidation_ShouldNotThrowException(EndGameCondition endGameCondition, int? maxRounds, int? maxPoints)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = endGameCondition,
                MaxRounds = maxRounds,
                MaxPoints = maxPoints
            };

            // Act
            dto.Validate();
        }
    }
}
