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
            var games = from game in Games
                where game.IsHomeGame
                select game;

            return games.ToList();
        }

        public IEnumerable<Game> GetAllExternalGames()
        {
            return Games.Where(g => !g.IsHomeGame);
        }
        
    }
}
