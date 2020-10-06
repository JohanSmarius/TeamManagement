using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IOpponentRepository
    {
        IEnumerable<Opponent> GetAll();
        Opponent GetById(int id);
        Opponent GetByName(string name);
    }
}