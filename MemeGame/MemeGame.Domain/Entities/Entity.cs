using MemeGame.Domain.Common;

namespace MemeGame.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
