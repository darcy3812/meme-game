using MemeGame.Domain.Entities;
using MemeGame.Domain.GameUsers;
using System.Collections.Generic;

namespace MemeGame.Domain
{
    public class Round : Entity
    {
        public GameUser Judge { get; set; }
        public int JudgeId { get; set; }
        public Situation Situation { get; set; }
        public int SituationId { get; set; }
        public List<RoundAnswer> RoundAnswers { get; set; }
    }
}
