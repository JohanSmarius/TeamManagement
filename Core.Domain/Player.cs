using System.Collections.Generic;

namespace Core.Domain
{
    public class Player
    {
        public string Name { get; set; }
        
        public int PlayerNumber { get; set; }

        public string EmailAddress { get; set; }

        public List<CareTaker> CareTakers { get; set; } = new List<CareTaker>();

        public override string ToString()
        {
            return $"{Name}-{PlayerNumber}";
        }
    }
}
