using MemeGame.Domain.Entities;

namespace MemeGame.Domain
{
    public class FileMetadata : Entity
    {
        public string Extension { get; set; }
        public string IdInExternalStorage { get; set; }
        public string ExternalStorage { get; set; }
    }
}
