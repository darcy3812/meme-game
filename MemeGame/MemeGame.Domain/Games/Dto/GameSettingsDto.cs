namespace MemeGame.Domain.Games.Dto
{
    public class GameSettingsDto
    {
        public int MaxPlayers { get; set; }
        public int SecondsToAnswer { get; set; }
        public EndGameCondition EndGameCondition { get; set; }
        public int? MaxRounds { get; set; }
        public int? MaxPoints { get; set; }
    }
}
