using System;
using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IGameRepository
    {
        List<Game> Games { get; set; }
        IEnumerable<Game> GetAll();
        IEnumerable<Game> GetAllHomeGames();
        IEnumerable<Game> GetAllExternalGames();
        IEnumerable<Game> Filter(Func<Game, bool> filterExpressie);
        void AddGame(Game newGame);
    }
}
