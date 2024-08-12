using MemeGame.Domain.Entities;

namespace MemeGame.Domain
{
    public class GameSetting : Entity
    {
        public int MaxPlayers { get; set; }
        public int SecondsToAnswer { get; set; }
        public EndGameCondition EndGameCondition { get; set; }
        public int? MaxRounds { get; set; }
        public int? MaxPoints { get; set; }
    }
}