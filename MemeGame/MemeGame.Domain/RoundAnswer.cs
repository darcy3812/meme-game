using MemeGame.Domain.Entities;
using MemeGame.Domain.GameUsers;

namespace MemeGame.Domain
{
    public class RoundAnswer : Entity
    {
        public Round Round { get; set; }
        public int RoundId { get; set; }
        public GameUser User { get; set; }
        public int UserId { get; set; }
        public Meme Meme { get; set; }
        public int MemeId { get; set; }
        public bool IsBest { get; set; }
    }
}