using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _context;
        private List<Game> Games { get; set; }

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return Games;
        }

        public IEnumerable<Game> GetAllHomeGames()
        {
               var games = from game in Games
                where game.IsHomeGame
                select game;

            return games.ToList();
        }

        public IEnumerable<Game> GetAllExternalGames()
        {
            return Games.Where(g => !g.IsHomeGame);
        }

        public IEnumerable<Game> Filter(Func<Game, bool> filterExpressie)
        {
            foreach (var game in Games)
            {
                if (filterExpressie(game))
                {
                    yield return game;
                }
            }
        }

        public async Task AddGame(Game newGame)
        {
            Games.Add(newGame);
            //await _context.SaveChangesAsync();
        }
    }
}
