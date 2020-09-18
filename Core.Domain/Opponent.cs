namespace Core.Domain
{
    public class Opponent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address PlayingAddress { get; set; }
    }
}