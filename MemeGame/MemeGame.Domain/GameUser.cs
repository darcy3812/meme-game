using MemeGame.Domain.Games;

namespace MemeGame.Domain
{
    public class GameUser
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}
