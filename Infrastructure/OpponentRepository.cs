using System;
using System.Collections.Generic;
using System.Linq;
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
            return _context.Opponents;
        }

        public Opponent GetById(int id)
        {
            return _context.Opponents.SingleOrDefault(opponent => opponent.Id == id);
        }

        public Opponent GetByName(string name)
        {
            return _context.Opponents.SingleOrDefault(opponent => opponent.Name.ToUpper() == name.ToUpper());
        }


    }
}