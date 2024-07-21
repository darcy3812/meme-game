using MemeGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeGame.Infrastructure.Persistance.Configurations
{
    public class SituationConfiguration : IEntityTypeConfiguration<Situation>
    {
        public void Configure(EntityTypeBuilder<Situation> builder)
        {
            builder.Property(t => t.Text)
                .IsRequired();            
        }
    }
}
