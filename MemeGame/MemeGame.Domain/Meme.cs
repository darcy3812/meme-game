using MemeGame.Domain.Entities;

namespace MemeGame.Domain
{
    public class Meme : Entity
    {      
        public byte[] Content { get; set; }
        public string Extension { get; set; }
    }
}
