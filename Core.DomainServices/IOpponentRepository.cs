using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IOpponentRepository
    {
        IEnumerable<Opponent> GetAll();
        Opponent Get(int id);
        Opponent Get(string name);
        Task AddAsync(Opponent opponent);
    }
}