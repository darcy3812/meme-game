using System;
using System.Collections.Generic;

namespace MemeGame.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public List<User> Users { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsFinished { get; set; }
        public GameSetting GameSettings { get; set; }
        public int GameSettingsId { get; set; }
    }
}
