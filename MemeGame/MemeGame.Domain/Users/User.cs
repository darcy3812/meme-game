using MemeGame.Domain.Entities;

namespace MemeGame.Domain.Users
{
    public class User : Entity
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
    }
}
