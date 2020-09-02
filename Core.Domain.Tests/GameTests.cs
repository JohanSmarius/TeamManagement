using System;
using Xunit;
using Xunit.Sdk;

namespace Core.Domain.Tests
{
    public class GameTests
    {
        [Fact]
        public void TestCoach()
        {
            const string EmptyCoach = "Not known";

            // Arrange
            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), false);

            // Act
            var coach = game.Coach?.Name ?? EmptyCoach;

            // Assert
            Assert.True(string.CompareOrdinal(coach, EmptyCoach) == 0);
        }

        [Fact]
        public void Given_Coach_AssignedToGame_Should_Return_Coach_Name()
        {
            // Arrange
            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), false)
            {
                Coach = new Coach { Name = "Tim" }
            };

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


        [Fact]
        public void Given_Game_Home_Properyt_Cannot_BeChanged()
        {
            // Arrange
            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), true);

            // Act
            game.IsHomeGame = false;

            // Assert
            throw new NotSupportedException();
        }

    }
}
