﻿using MemeGame.Domain.Entities;
using MemeGame.Domain.GameUsers;
using MemeGame.Domain.Users;
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
        public GameStatus GameStatus { get; set; }
        public GameSetting GameSettings { get; set; }
        public int GameSettingsId { get; set; }
        public  User Author { get; set; }
        public int AuthorId { get; set; }
    }
}
