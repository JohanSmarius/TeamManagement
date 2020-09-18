using System.Collections.Generic;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GameDbContext _context;

        public PlayerRepository(GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Players;
        }
    }
}