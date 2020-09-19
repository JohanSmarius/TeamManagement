using System.Collections.Generic;
using System.Reflection;

namespace Core.Domain
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int PlayerNumber { get; set; }

        public string EmailAddress { get; set; }

        public virtual Team Team { get; set; }
        public int TeamId { get; set; }

        public virtual ICollection<PlayerGame> PlayerGames { get; set; }

        public virtual ICollection<CareTaker> CareTakers { get; set; } = new List<CareTaker>();

        public override string ToString()
        {
            return $"{Name}-{PlayerNumber}";
        }
    }
}
