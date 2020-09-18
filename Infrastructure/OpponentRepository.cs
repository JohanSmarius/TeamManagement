using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class OpponentRepository : IOpponentRepository
    {
        private readonly GameDbContext _context;

        public OpponentRepository(GameDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public IEnumerable<Opponent> GetAll()
        {
            return _context.Opponents.ToList();
        }

        public Opponent Get(int id)
        {
            return _context.Opponents.Find(id);
        }

        public Opponent Get(string name)
        {
            return _context.Opponents.SingleOrDefault(o => o.Name == name);
        }

        public async Task AddAsync(Opponent opponent)
        {
            _context.Add(opponent);
            
            await _context.SaveChangesAsync();
        }
    }
}