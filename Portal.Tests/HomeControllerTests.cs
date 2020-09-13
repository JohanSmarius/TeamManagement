using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core.Domain;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Moq;
using Portal.Controllers;
using Portal.Models;
using Xunit;

namespace Portal.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Should_Return_Index_View()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var gameRepoMock = new Mock<IGameRepository>();
            var coachRepoMock = new Mock<ICoachRepository>();
            var playerRepoMock = new Mock<IPlayerRepository>();
            var sut = new HomeController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
                playerRepoMock.Object);

            gameRepoMock.Setup(gameRepo => gameRepo.Games).Returns(new List<Game>()
            {
                new Game(DateTime.Today, true),
                new Game(DateTime.Today.AddDays(7), false)
            });

            // Act
            var result = sut.Index() as ViewResult;

            // Assert
            Assert.Null(result.ViewName);

        }


        [Fact] 
        public void Index_Should_Return_Games_In_Model()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var gameRepoMock = new Mock<IGameRepository>();
            var coachRepoMock = new Mock<ICoachRepository>();
            var playerRepoMock = new Mock<IPlayerRepository>();
            var sut = new HomeController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
                playerRepoMock.Object);

            var date1 = DateTime.Today;
            var date2 = DateTime.Today.AddDays(7);
            gameRepoMock.Setup(gameRepo => gameRepo.Games).Returns(new List<Game>()
            {
                new Game(date1, true),
                new Game(date2, false)
            });

            // Act
            var result = sut.Index() as ViewResult;

            // Assert
            var gamesInModel = result.Model as List<GamesViewModel>;
            Assert.Equal(2, gamesInModel.Count);
            Assert.Equal(date1, gamesInModel.First().PlayTime);
            Assert.Equal(date2, gamesInModel.Last().PlayTime);
        }

        [Fact] 
        public void NewGame_Should_Return_Prefilled_Game()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var gameRepoMock = new Mock<IGameRepository>();
            var coachRepoMock = new Mock<ICoachRepository>();
            var playerRepoMock = new Mock<IPlayerRepository>();
            var sut = new HomeController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
                playerRepoMock.Object);

            coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
            {
                new Coach() { Name = "Bill Gates" }
            });

            playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
            {
                new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
                {
                    new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
                }}
            });

            // Act
            var result = sut.NewGame();

            // Assert
            var viewResult = result as ViewResult;
            var newGameModel = viewResult.Model as NewGameViewModel;

            Assert.NotNull(newGameModel);
        }

        [Fact]
        public void NewGame_Should_Return_Coaches_In_ViewBag()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var gameRepoMock = new Mock<IGameRepository>();
            var coachRepoMock = new Mock<ICoachRepository>();
            var playerRepoMock = new Mock<IPlayerRepository>();
            var sut = new HomeController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
                playerRepoMock.Object);

            coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
            {
                new Coach() { Name = "Bill Gates" }
            });

            playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
            {
                new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
                {
                    new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
                }}
            });

            // Act
            var result = sut.NewGame();

            // Assert
            var viewResult = result as ViewResult;
            var coaches = viewResult.ViewData["coaches"] as SelectList;
            var items = coaches.Items.Cast<Coach>();

            Assert.Equal(2, items.Count());
        }

        [Fact]
        public void NewGame_Should_Return_Default_Coach_In_ViewBag()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var gameRepoMock = new Mock<IGameRepository>();
            var coachRepoMock = new Mock<ICoachRepository>();
            var playerRepoMock = new Mock<IPlayerRepository>();
            var sut = new HomeController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
                playerRepoMock.Object);

            coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
            {
                new Coach() { Name = "Bill Gates" }
            });

            playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
            {
                new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
                {
                    new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
                }}
            });

            // Act
            var result = sut.NewGame();

            // Assert
            var viewResult = result as ViewResult;
            var coaches = viewResult.ViewData["coaches"] as SelectList;
            var items = coaches.Items.Cast<Coach>();

            Assert.Equal(-1, items.First().Id);
            Assert.Equal("Select a coach", items.First().Name);
        }


        [Fact]
        public void NewGame_Should_Return_Coach_From_Repository_In_ViewBag()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var gameRepoMock = new Mock<IGameRepository>();
            var coachRepoMock = new Mock<ICoachRepository>();
            var playerRepoMock = new Mock<IPlayerRepository>();
            var sut = new HomeController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
                playerRepoMock.Object);

            coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
            {
                new Coach() { Id = 0, Name = "Bill Gates" }
            });

            playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
            {
                new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
                {
                    new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
                }}
            });

            // Act
            var result = sut.NewGame();

            // Assert
            var viewResult = result as ViewResult;
            var coaches = viewResult.ViewData["coaches"] as SelectList;
            var items = coaches.Items.Cast<Coach>();
            var coach = items.Single(coach => coach.Id == 0);

            Assert.Equal(0, coach.Id );
            Assert.Equal("Bill Gates", coach.Name);
        }
    }
}
