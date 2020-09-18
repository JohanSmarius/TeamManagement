namespace Core.Domain
{
    public class PlayerGame
    {
        public int PlayerID { get; set; }
        public int GameID { get; set; }

        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}