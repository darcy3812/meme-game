using MemeGame.Domain.Entities;
using MemeGame.Domain.Games;

namespace MemeGame.Domain
{
    public class GameUser : Entity
    {
        public int Points { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}
