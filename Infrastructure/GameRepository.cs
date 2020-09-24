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

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Example of explicit loading
        /// </summary>
        public void PreLoad()
        {
            var firstGame = _context.Games.FirstOrDefault();

            if (firstGame != null)
            {
                _context.Entry(firstGame).Collection(game => game.PlayerGames).Load();
                _context.Entry(firstGame).Reference(game => game.Coach).Load();
            }
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.Include(g => g.Coach).Include(g => g.Opponent).Include(g => g.PlayerGames).ThenInclude(pg => pg.Player).ThenInclude(p => p.CareTakers);
        }

        public IEnumerable<Game> GetAllHomeGames()
        {
            var games = from game in _context.Games
                where game.IsHomeGame
                select game;

            return games.ToList();
        }

        public IEnumerable<Game> GetAllExternalGames()
        {
            return _context.Games.Where(g => !g.IsHomeGame);
        }

        public IEnumerable<Game> Filter(Func<Game, bool> filterExpressie)
        {
            foreach (var game in _context.Games)
            {
                if (filterExpressie(game))
                {
                    yield return game;
                }
            }
        }

        public async Task AddGame(Game newGame)
        {
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
        }
    }
}
