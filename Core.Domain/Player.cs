namespace Core.Domain
{
    public class Player
    {
        public string Name { get; set; }
        
        public int PlayerNumber { get; set; }

        public string EmailAddress { get; set; }

        public override string ToString()
        {
            return $"{Name}-{PlayerNumber}";
        }
    }
}
