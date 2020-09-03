using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Xunit;

using static Infrastructure.FilterExtensions;

namespace Infrastructure.Tests
{
    public class GameRepositoryTests
    {
        [Fact]
        public void Given_Games_HomeGames_Can_Be_Retrieved()
        {
            // Arrange
            var sut = new GameRepository() {Games = CreateGames()};

            // Act
            var homeGames = sut.GetAllHomeGames();

            // Assert
            Assert.Equal(5, homeGames.Count());
        }
        
        [Fact]
        public void Given_Games_ExternalGames_Can_Be_Retrieved()
        {
            // Arrange
            var sut = new GameRepository() {Games = CreateGames()};

            // Act
            var externalGames = sut.GetAllExternalGames();

            // Assert
            Assert.Equal(3, externalGames.Count());
        }

        [Fact]
        public void Filter_Given_Games_ExternalGames_Can_Be_Retrieved()
        {
            // Arrange
            var sut = new GameRepository() {Games = CreateGames()};

            // Act
            var externalGames = new List<Game>();

            // Assert
            Assert.Equal(3, externalGames.Count());
        }
        
        [Fact]
        public void Filter_Given_Games_HomeGames_From_Date_Can_Be_Retrieved()
        {
            // Arrange
            var sut = new GameRepository() {Games = CreateGames()};

            // Act
            var externalGames = new List<Game>();
            
            // Assert
            Assert.Equal(2, externalGames.Count());
        }

        [Fact]
        public void FilterAsExtension_Given_Games_HomeGames_From_Date_Can_Be_Retrieved()
        {
            // Arrange
            var sut = new GameRepository() { Games = CreateGames() };

            // Act
            var externalGames = new List<Game>();

            // Assert
            Assert.Equal(2, externalGames.Count());
        }


        private List<Game> CreateGames()
        {
            return new List<Game>();
        }
    }
}
