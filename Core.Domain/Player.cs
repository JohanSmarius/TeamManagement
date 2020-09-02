namespace Core.Domain
{
    public class Player : IPerson
    {
        public string Name { get; set; }
        
        public int PlayerNumber { get; set; }

        public int TotalScore { get; set; }

        public string EmailAddress { get; set; }

        public override string ToString()
        {
            return $"{Name}-{PlayerNumber}";
        }
    }
}
