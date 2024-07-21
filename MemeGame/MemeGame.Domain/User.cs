namespace MemeGame.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}
