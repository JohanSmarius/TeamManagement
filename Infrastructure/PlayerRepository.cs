using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure
{
    public class PlayerRepository
    {
        public List<Player> GetPlayers()
        {
            return PlayerSeeder.SeedPlayers();
        }
    }
}