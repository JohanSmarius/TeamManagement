namespace Core.Domain
{
    public class PlayerGame
    {
        public int PlayerID { get; set; }
        public int GameID { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
    }
}