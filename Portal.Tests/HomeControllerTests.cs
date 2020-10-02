namespace Portal.Tests
{
    public class GameControllerTests
    {
        //[Fact]
        //public void Index_Should_Return_Index_View()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    gameRepoMock.Setup(gameRepo => gameRepo.GetAll()).Returns(new List<Game>()
        //    {
        //        new Game(DateTime.Today, true),
        //        new Game(DateTime.Today.AddDays(7), false)
        //    });

        //    // Act
        //    var result = sut.Index() as ViewResult;

        //    // Assert
        //    Assert.Null(result.ViewName);

        //}


        //[Fact] 
        //public void Index_Should_Return_Games_In_Model()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    var date1 = DateTime.Today;
        //    var date2 = DateTime.Today.AddDays(7);
        //    gameRepoMock.Setup(gameRepo => gameRepo.GetAll()).Returns(new List<Game>()
        //    {
        //        new Game(date1, true),
        //        new Game(date2, false)
        //    });

        //    // Act
        //    var result = sut.Index() as ViewResult;

        //    // Assert
        //    var gamesInModel = result.Model as List<GamesViewModel>;
        //    Assert.Equal(2, gamesInModel.Count);
        //    Assert.Equal(date1, gamesInModel.First().PlayTime);
        //    Assert.Equal(date2, gamesInModel.Last().PlayTime);
        //}

        //[Fact] 
        //public void NewGame_Should_Return_Prefilled_Game()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
        //    {
        //        new Coach() { Name = "Bill Gates" }
        //    });

        //    playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
        //    {
        //        new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
        //        {
        //            new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
        //        }}
        //    });

        //    // Act
        //    var result = sut.NewGame();

        //    // Assert
        //    var viewResult = result as ViewResult;
        //    var newGameModel = viewResult.Model as NewGameViewModel;

        //    Assert.NotNull(newGameModel);
        //}

        //[Fact]
        //public void NewGame_Should_Return_Coaches_In_ViewBag()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
        //    {
        //        new Coach() { Name = "Bill Gates" }
        //    });

        //    playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
        //    {
        //        new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
        //        {
        //            new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
        //        }}
        //    });

        //    // Act
        //    var result = sut.NewGame();

        //    // Assert
        //    var viewResult = result as ViewResult;
        //    var coaches = viewResult.ViewData["coaches"] as SelectList;
        //    var items = coaches.Items.Cast<Coach>();

        //    Assert.Equal(2, items.Count());
        //}

        //[Fact]
        //public void NewGame_Should_Return_Default_Coach_In_ViewBag()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
        //    {
        //        new Coach() { Name = "Bill Gates" }
        //    });

        //    playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
        //    {
        //        new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
        //        {
        //            new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
        //        }}
        //    });

        //    // Act
        //    var result = sut.NewGame();

        //    // Assert
        //    var viewResult = result as ViewResult;
        //    var coaches = viewResult.ViewData["coaches"] as SelectList;
        //    var items = coaches.Items.Cast<Coach>();

        //    Assert.Equal(-1, items.First().Id);
        //    Assert.Equal("Select a coach", items.First().Name);
        //}


        //[Fact]
        //public void NewGame_Should_Return_Coach_From_Repository_In_ViewBag()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
        //    {
        //        new Coach() { Id = 0, Name = "Bill Gates" }
        //    });

        //    playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
        //    {
        //        new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
        //        {
        //            new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
        //        }}
        //    });

        //    // Act
        //    var result = sut.NewGame();

        //    // Assert
        //    var viewResult = result as ViewResult;
        //    var coaches = viewResult.ViewData["coaches"] as SelectList;
        //    var items = coaches.Items.Cast<Coach>();
        //    var coach = items.Single(coach => coach.Id == 0);

        //    Assert.Equal(0, coach.Id );
        //    Assert.Equal("Bill Gates", coach.Name);
        //}

        //[Fact]
        //public async Task NewGame_Given_Departure_Time_For_Home_Game_Should_Return_ModelError()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
        //    {
        //        new Coach() { Id = 0, Name = "Bill Gates" }
        //    });

        //    playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
        //    {
        //        new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
        //        {
        //            new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
        //        }}
        //    });


        //    // Act
        //    var newGameModel = new NewGameViewModel()
        //    {
        //        IsHomeGame = true,
        //        DepartureTime = DateTime.Now
        //    };

        //    var result = await sut.NewGame(newGameModel);

        //    // Assert
        //    var viewResult = result as ViewResult;

        //    Assert.False(viewResult.ViewData.ModelState.IsValid);
        //    Assert.True(viewResult.ViewData.ModelState.ContainsKey(nameof(newGameModel.DepartureTime)));
        //    var key = nameof(newGameModel.DepartureTime);
        //    Assert.Equal("Vertrektijd mag niet op worden gegeven bij een thuiswedstrijd", 
        //        viewResult.ViewData.ModelState[key].Errors.First().ErrorMessage);
        //}
        
        //[Fact]
        //public void NewGame_Given_Empty_Opppenent_Should_Not_Save_Game()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<HomeController>>();
        //    var gameRepoMock = new Mock<IGameRepository>();
        //    var coachRepoMock = new Mock<ICoachRepository>();
        //    var playerRepoMock = new Mock<IPlayerRepository>();
        //    var opponentRepoMock = new Mock<IOpponentRepository>();

        //    var sut = new GameController(loggerMock.Object, gameRepoMock.Object, coachRepoMock.Object,
        //        playerRepoMock.Object, opponentRepoMock.Object);

        //    coachRepoMock.Setup(coachRepo => coachRepo.GetCoaches()).Returns(new List<Coach>
        //    {
        //        new Coach() { Id = 0, Name = "Bill Gates" }
        //    });

        //    playerRepoMock.Setup(playerRepo => playerRepo.GetPlayers()).Returns(new List<Player>()
        //    {
        //        new Player { Name = "Player3", PlayerNumber = 3, CareTakers = new List<CareTaker>()
        //        {
        //            new CareTaker { Id = 1, Name = "Parent1Player3", HasCar = true}
        //        }}
        //    });
            
        //    var newGameModel = new NewGameViewModel()
        //    {
        //        IsHomeGame = false,
        //        DepartureTime = DateTime.Now
        //    };

        //    // Act
        //    sut.ModelState.AddModelError("Opponent", "Opponent cannot be empty");
        //    sut.NewGame(newGameModel);

        //    // Assert
        //    gameRepoMock.Verify(gameRepoMock => gameRepoMock.AddGame(It.IsAny<Game>()), Times.Never);
        //}


    }
}
