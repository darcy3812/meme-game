using MemeGame.Domain.Entities;
using MemeGame.Domain.GameUsers;
using System;
using System.Collections.Generic;

namespace MemeGame.Domain.Games
{
    public class Game : Entity
    {
        public List<GameUser> GameUsers { get; set; } = new();
        public string Name { get; set; }
        public string Hash { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsFinished { get; set; }
        public GameSetting GameSettings { get; set; }
        public int GameSettingsId { get; set; }
    }
}
