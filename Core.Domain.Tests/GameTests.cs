using System;
using Xunit;
using Xunit.Sdk;

namespace Core.Domain.Tests
{
    public class GameTests
    {
        [Fact]
        public void Given_New_Game_Should_Show_Default_Name_For_Coach()
        {
            const string emptyCoach = "Not known";

            // Arrange
            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), false);

            // Act
            var coach = game.Coach.Name;

            // Assert
            Assert.True(string.CompareOrdinal(coach, emptyCoach) == 0);
        }

        [Fact]
        public void Given_Coach_AssignedToGame_Should_Return_Coach_Name()
        {
            // Arrange
            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), false);

            // Act
            var coach = game.Coach.Name;

            // Assert
            Assert.True(string.Compare(coach, "Tim", StringComparison.OrdinalIgnoreCase) == 0);
        }

        [Fact]
        public void Given_External_Game_DepartureTime_Can_Be_Set()
        {

            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), false);

            // Act
            game.DepartureTime = new DateTime(2020, 09, 06, 12, 30, 00);

            // Assert
            Assert.Equal(new DateTime(2020, 09, 06, 12, 30, 00), game.DepartureTime);
        }


        [Fact]
        public void Given_Home_Game_DepartureTime_Can_Not_Be_Set()
        {
            // Arrange
            var exceptionHasBeenThrown = false;

            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), true);

            try
            {
                // Act
                game.DepartureTime = new DateTime(2020, 09, 06, 12, 30, 00);
            }
            catch (InvalidOperationException)
            {
                exceptionHasBeenThrown = true;
            }

            // Assert
            Assert.True(exceptionHasBeenThrown);
        }

    }
}
