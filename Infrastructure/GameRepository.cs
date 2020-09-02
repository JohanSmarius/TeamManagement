using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;

namespace Infrastructure
{
    public class GameRepository
    {
        public List<Game> Games { get; set; }

        public IEnumerable<Game> GetAll()
        {
            return Games;
        }

        public IEnumerable<Game> GetAllHomeGames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAllExternalGames()
        {
            throw new NotImplementedException();
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
