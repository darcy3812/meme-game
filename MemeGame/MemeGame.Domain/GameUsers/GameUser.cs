using MemeGame.Domain.Entities;
using MemeGame.Domain.Games;
using MemeGame.Domain.Users;

namespace MemeGame.Domain.GameUsers
{
    public class GameUser : Entity
    {
        public int Points { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsAuthor { get; set; }
    }
}
