using MemeGame.Domain.Entities;

namespace MemeGame.Domain
{
    public class Meme : Entity
    {
        public FileMetadata FileMetadata { get; set; }
        public int FileMetadataId { get; set; }
    }
}
