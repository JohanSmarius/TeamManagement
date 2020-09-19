namespace Core.Domain
{
    public class Opponent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Address PlayingAddress { get; set; }
    }
}