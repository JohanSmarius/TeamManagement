using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace Core.Domain.Tests
{
    public class GameTests
    {
        [Fact]
        public void Given_New_Game_Should_ShowDefault_Name_For_Coach()
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
        public void Given_Game_Home_Property_Cannot_BeChanged()
        {
            // Arrange
            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), true);

            // Act
            game.IsHomeGame = false;

            // Assert
            throw new NotSupportedException();
        }

        [Fact]
        public void Given_People_Should_Calculate_Total_Score()
        {
            // Arrange
            var game = new Game(new DateTime(2020, 09, 06, 14, 30, 00), true);
            game.PeopleInvolved = new List<IPerson>
            {
                new Player() { Name = "Agnes", PlayerNumber = 50, TotalScore = 30},
                new Player() { Name = "Simone", PlayerNumber = 10, TotalScore = 20},
                new Player() { Name = "Yamila", PlayerNumber = 5, TotalScore = 50},
                new CareTaker { Name = "Johan", HasCar = true }
            };

            // Act
            var totalScore = game.GetTotalScore();

            // Assert
            Assert.Equal(100, totalScore);
        }



    }
}
