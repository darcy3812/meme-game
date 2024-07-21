using MemeGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeGame.Infrastructure.Persistance.Configurations
{
    public class RoundAnswerConfiguration : IEntityTypeConfiguration<RoundAnswer>
    {
        public void Configure(EntityTypeBuilder<RoundAnswer> builder)
        {
            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.RoundId)
                .IsRequired();

            builder.Property(t => t.MemeId)
                .IsRequired();
        }
    }
}
