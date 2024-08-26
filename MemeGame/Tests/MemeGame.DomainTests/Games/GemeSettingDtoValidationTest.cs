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
        public void InvalidMaxPlayer_ShouldThrowException(int MaxPlayers)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = MaxPlayers,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = 5,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(3)]
        [TestCase(10)]
        public void ValidMaxPlayer_ShouldNotThrowException(int MaxPlayers)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = MaxPlayers,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = 5,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();
           
        }

        [TestCase(2)]
        public void InvalidSecondsToAnswer_ShouldThrowException(int SecondsToAnswer)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = SecondsToAnswer,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = 5,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(5)]
        [TestCase(10)]
        public void ValidSecondsToAnswer_ShouldNotThrowException(int SecondsToAnswer)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = SecondsToAnswer,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = 5,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();
           
        }


        [TestCase(0)]
        public void InvalidMaxRounds_ShouldThrowException(int MaxRounds)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByRounds,
                MaxRounds = MaxRounds,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(2)]
        [TestCase(10)]
        public void ValidMaxRounds_ShouldNotThrowException(int MaxRounds)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByRounds,
                MaxRounds = MaxRounds,
                MaxPoints = 5
            };

            // Act
            var action = () => dto.Validate();

        }

        [TestCase(0)]
        public void InvalidMaxPoints_ShouldThrowException(int MaxPoints)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByPoints,
                MaxRounds = 5,
                MaxPoints = MaxPoints
            };

            // Act
            var action = () => dto.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }

        [TestCase(2)]
        [TestCase(10)]
        public void ValidMaxPoints_ShouldNotThrowException(int MaxPoints)
        {
            // Arrange
            var dto = new GameSettingsDto()
            {
                MaxPlayers = 3,
                SecondsToAnswer = 5,
                EndGameCondition = EndGameCondition.ByRounds,
                MaxRounds = 5,
                MaxPoints = MaxPoints
            };

            // Act
            var action = () => dto.Validate();

        }
    }
}
