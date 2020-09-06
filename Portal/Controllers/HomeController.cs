﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Portal.Models;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameRepository _gameRepository;
        private readonly CoachRepository _coachRepository;
        private readonly PlayerRepository _playerRepository;

        public HomeController(ILogger<HomeController> logger, 
            GameRepository gameRepository, 
            CoachRepository coachRepository, 
            PlayerRepository playerRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
            _coachRepository = coachRepository;
            _playerRepository = playerRepository;
        }

        public IActionResult Index()
        {
            
            
            return View(_gameRepository.Games.ToViewModel());
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

        [HttpGet]
        public IActionResult NewGame()
        {
            var model = new NewGameViewModel();
            PrefillSelectOptions();

            return View(model);
        }

        [HttpPost]
        public IActionResult NewGame(NewGameViewModel newGame)
        {
            if (newGame.IsHomeGame && newGame.DepartureTime.HasValue)
            {
                ModelState.AddModelError(nameof(newGame.DepartureTime),
                    "Vertrektijd mag niet op worden gegeven bij een thuiswedstrijd");
            }

            if (ModelState.IsValid)
            {
                var gameToCreate = new Game(newGame.PlayTime, newGame.IsHomeGame);
                
                gameToCreate.Opponent = new Opponent() { Name = newGame.Opponent };

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

                _gameRepository.Games.Add(gameToCreate);

                return RedirectToAction("Index");
            }

            
            PrefillSelectOptions();
            return View(newGame);

        } 
        
        
        private void PrefillSelectOptions()
        {
            var coaches = _coachRepository.GetCoaches().Prepend(new Coach() { Id = -1, Name = "Select a coach" });
            ViewBag.Coaches = new SelectList(coaches, "Id", "Name");

            var careTakers = _playerRepository.GetPlayers().SelectMany(p => p.CareTakers)
                .Prepend(new CareTaker { Id = -1, Name = "Select a caretaker" });
            ViewBag.CareTakers = new SelectList(careTakers, "Id", "Name");
        }

    }
}
