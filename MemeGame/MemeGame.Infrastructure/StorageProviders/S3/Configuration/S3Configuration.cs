using System;
using System.ComponentModel.DataAnnotations;

namespace MemeGame.Infrastructure.StorageProviders.S3.Configuration
{
    public class S3Configuration
    {
        public static readonly string SectionName = "S3";

        [Required]
        public Uri Endpoint { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public string BucketName { get; set; }

        [Required]
        public string Region { get; set; }
    }
}
