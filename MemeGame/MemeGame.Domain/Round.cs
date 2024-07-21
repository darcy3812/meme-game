using System.Collections.Generic;

namespace MemeGame.Domain
{
    public class Round
    {
        public int Id { get; set; }
        public User Judge { get; set; }
        public int JudgeId { get; set; }
        public Situation Situation { get; set; }
        public int SituationId { get; set; }
        public List<RoundAnswer> RoundAnswers { get; set; }
    }
}
