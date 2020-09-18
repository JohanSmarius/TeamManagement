using System.Collections.Generic;

namespace Core.Domain
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}