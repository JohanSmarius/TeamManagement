using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class GameRepository : IGameRepository
    {
        public List<Game> Games { get; set; }

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
    }
}
