using System.Collections.Generic;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class PlayerRepository : IPlayerRepository
    {
        public List<Player> GetPlayers()
        {
            return PlayerSeeder.SeedPlayers();
        }
    }
}