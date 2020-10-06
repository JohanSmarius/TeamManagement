using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamWebService.Models;

namespace TeamWebService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ILogger<GamesController> _logger;
        private readonly IGameRepository _gameRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IOpponentRepository _opponentRepository;
        private readonly IMapper _mapper;


        public GamesController(ILogger<GamesController> logger, 
            IGameRepository gameRepository, 
            ICoachRepository coachRepository, 
            IPlayerRepository playerRepository, 
            IOpponentRepository opponentRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _coachRepository = coachRepository ?? throw new ArgumentNullException(nameof(coachRepository));
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _opponentRepository = opponentRepository ?? throw new ArgumentNullException(nameof(opponentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public List<Game> Get()
        {
            return _gameRepository.GetAllGames().ToList();
        }

        [HttpGet("{id}")]
        public async Task<Game> Get(int id)
        {
            return await _gameRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<NewCreatedGameDto>> AddGame(NewGameDTO newGame)
        {
            // No need to call ModelState.IsValid. It is checked
            // automatically because of the use of [ApiController]


            var gameToCreate = new Game(newGame.PlayTime, newGame.IsHomeGame);

            if (newGame.CoachId.HasValue)
            {
                var selectedCoach = _coachRepository.GetById(newGame.CoachId.Value);
                gameToCreate.Coach = selectedCoach;
            }

            if (newGame.LaundryDutyId.HasValue)
            {
                var careTakers = _playerRepository.GetPlayers().SelectMany(p => p.CareTakers);
                var selectedCareTakerForLaundryDuty =
                    careTakers.SingleOrDefault(careTaker => careTaker.Id == newGame.LaundryDutyId);
                gameToCreate.LaundryDuty = selectedCareTakerForLaundryDuty;
            }

            var opponent = _opponentRepository.GetByName(newGame.Opponent);

            if (opponent == null)
            {
                gameToCreate.Opponent = new Opponent() {Name = newGame.Opponent};
            }
            else
            {
                gameToCreate.Opponent = opponent;
            }

            await _gameRepository.AddGame(gameToCreate);

            var createdResource = _mapper.Map<NewCreatedGameDto>(newGame);
            createdResource.Id = gameToCreate.Id;

            return CreatedAtAction(nameof(Get), new {id = createdResource.Id}, createdResource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var game = await _gameRepository.GetById(id);
            await _gameRepository.Delete(game);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatedGameDTO>> Update(int id, [FromBody]UpdateGameDTO gameToChange)
        {
            var game = await _gameRepository.GetById(id);

            // Sanity check
            if ((game == null) || (id != gameToChange.Id))
            {
                return BadRequest();
            }

            if (gameToChange.CoachId.HasValue)
            {
                var selectedCoach = _coachRepository.GetById(gameToChange.CoachId.Value);
                game.Coach = selectedCoach;
            }

            if (gameToChange.LaundryDutyId.HasValue)
            {
                var careTakers = _playerRepository.GetPlayers().SelectMany(p => p.CareTakers);
                var selectedCareTakerForLaundryDuty =
                    careTakers.SingleOrDefault(careTaker => careTaker.Id == gameToChange.LaundryDutyId);
                game.LaundryDuty = selectedCareTakerForLaundryDuty;
            }

            if (gameToChange.DepartureTime.HasValue)
            {
                game.DepartureTime = gameToChange.DepartureTime;
            }

            var opponent = _opponentRepository.GetByName(gameToChange.Opponent);

            if (opponent == null)
            {
                game.Opponent = new Opponent() { Name = gameToChange.Opponent };
            }
            else
            {
                game.Opponent = opponent;
            }

            await _gameRepository.Update(game);

            var resultToReturn = _mapper.Map<UpdatedGameDTO>(game);
            
            return new OkObjectResult(resultToReturn);
        }
    }
}
