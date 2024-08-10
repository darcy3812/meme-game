using MemeGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeGame.Infrastructure.Persistance.Configurations
{
    public class FileMetadataConfiguration : IEntityTypeConfiguration<FileMetadata>
    {
        public void Configure(EntityTypeBuilder<FileMetadata> builder)
        {
            builder.Property(f => f.ExternalStorage)
                .IsRequired();
            builder.Property(f => f.IdInExternalStorage)
                .IsRequired();
            builder.Property(f => f.Extension)
                .IsRequired();
        }
    }
}
