using MemeGame.Application.FileStorage;
using System.IO;

namespace MemeGame.Infrastructure.FileStorages
{
    public class FileSummary : IFileSummary
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public Stream Stream { get; set; }
    }
}
