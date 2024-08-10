using System.ComponentModel.DataAnnotations;

namespace MemeGame.Infrastructure.StorageProviders
{
    public class StorageConfiguration
    {
        public static readonly string SectionName = "Storage";

        [Required]
        public string StorageProvider { get; set; }
    }
}
