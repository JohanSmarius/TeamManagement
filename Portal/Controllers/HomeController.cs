using System.Diagnostics;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGameRepository _gameRepository;
    private readonly ICoachRepository _coachRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IOpponentRepository _opponentRepository;

    public HomeController(ILogger<HomeController> logger, 
        IGameRepository gameRepository, 
        ICoachRepository coachRepository, 
        IPlayerRepository playerRepository,
        IOpponentRepository opponentRepository)
    {
        _logger = logger;
        _gameRepository = gameRepository;
        _coachRepository = coachRepository;
        _playerRepository = playerRepository;
        _opponentRepository = opponentRepository ?? throw new ArgumentNullException(nameof(opponentRepository));
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
