using System.ComponentModel.DataAnnotations;

namespace MemeGame.Infrastructure.StorageProviders.Local.Configuration
{
    public class LocalStorageConfiguration
    {
        public static readonly string SectionName = "LocalStorage";

        [Required]
        public string FolderPath { get; set; }
    }
}
