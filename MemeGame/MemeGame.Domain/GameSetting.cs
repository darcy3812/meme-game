namespace MemeGame.Domain
{
    public class GameSetting
    {
        public int Id { get; set; }
        public int MaxPlayers { get; set; }
        public int SecondsToAnswer { get; set; }
        public EndGameCondition EndGameCondition { get; set; }
        public int? MaxRounds { get; set; }        
        public int? MaxPoints { get; set; }
    }
}