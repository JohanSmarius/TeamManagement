using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IGameRepository
    {
        IQueryable<Game> GetAll();
        IEnumerable<Game> GetAllHomeGames();
        IEnumerable<Game> GetAllExternalGames();
        IEnumerable<Game> Filter(Func<Game, bool> filterExpressie);
        Task AddGame(Game newGame);
    }
}
