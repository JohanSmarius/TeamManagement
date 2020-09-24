using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Portal.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameRepository _gameRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IOpponentRepository _opponentRepository;


        public GameController(ILogger<HomeController> logger,
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

        [Authorize]
        public IActionResult Index()
        {
            return View(_gameRepository.GetAll().ToViewModel());
        }

        [Authorize]
        public IActionResult List(string team)
        {
            var model = _gameRepository.GetAll().Include(game => game.Team)
                .Where(game => team == null || game.Team.Name == team).OrderByDescending(game => game.PlayTime).ToList().ToViewModel();

            return View(model);
        }

        [Authorize(Policy = "TeamManagerOnly")]
        [HttpGet]
        public IActionResult NewGame()
        {
            var model = new NewGameViewModel();

            PrefillSelectOptions();

            return View(model);
        }

        private void PrefillSelectOptions()
        {
            var coaches = _coachRepository.GetCoaches().Prepend(new Coach() { Id = -1, Name = "Select a coach" });
            ViewBag.Coaches = new SelectList(coaches, "Id", "Name");

            var careTakers = _playerRepository.GetPlayers().SelectMany(p => p.CareTakers)
                .Prepend(new CareTaker { Id = -1, Name = "Select a caretaker" });
            ViewBag.CareTakers = new SelectList(careTakers, "Id", "Name");
        }

        [Authorize(Policy = "TeamManagerOnly")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> NewGame(NewGameViewModel newGame)
        {
            if (newGame.IsHomeGame && newGame.DepartureTime.HasValue)
            {
                ModelState.AddModelError(nameof(newGame.DepartureTime),
                    "Vertrektijd mag niet op worden gegeven bij een thuiswedstrijd");
            }

            if (ModelState.IsValid)
            {
                var gameToCreate = new Game(newGame.PlayTime, newGame.IsHomeGame);

                if (newGame.CoachId != -1)
                {
                    var selectedCoach = _coachRepository.GetById(newGame.CoachId);
                    gameToCreate.Coach = selectedCoach;
                }

                if (newGame.LaundryDutyId != -1)
                {
                    var careTakers = _playerRepository.GetPlayers().SelectMany(p => p.CareTakers);
                    var selectedCareTakerForLaundryDuty =
                        careTakers.SingleOrDefault(careTaker => careTaker.Id == newGame.LaundryDutyId);
                    gameToCreate.LaundryDuty = selectedCareTakerForLaundryDuty;
                }

                await _gameRepository.AddGame(gameToCreate);

                return RedirectToAction("Index");
            }

            PrefillSelectOptions();

            return View(newGame);

        }

    }
}
