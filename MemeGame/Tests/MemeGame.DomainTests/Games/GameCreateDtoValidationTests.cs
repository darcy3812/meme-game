using MemeGame.Common.Extensions;
using MemeGame.Domain.Games.Dto;
using Shouldly;
using System.ComponentModel.DataAnnotations;

namespace MemeGame.DomainTests.Games
{
    [TestFixture]
    public class GameCreateDtoValidationTests
    {
        [TestCase("")]
        [TestCase("123")]
        public void InvalidName_ShouldThrowException(string name)
        {
            // Arrange
            var game = new GameCreatedDto()
            {
                Name = name
            };

            // Act
            var action = () => game.Validate();

            //Assert
            action.ShouldThrow<ValidationException>();
        }
    }
}
