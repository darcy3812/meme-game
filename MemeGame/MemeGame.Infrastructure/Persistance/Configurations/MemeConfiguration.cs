using MemeGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeGame.Infrastructure.Persistance.Configurations
{
    public class MemeConfiguration : IEntityTypeConfiguration<Meme>
    {
        public void Configure(EntityTypeBuilder<Meme> builder)
        {
            builder.Property(t => t.Content)
                .IsRequired();

            builder.Property(t => t.Extension)
                .IsRequired();            
        }
    }
}
