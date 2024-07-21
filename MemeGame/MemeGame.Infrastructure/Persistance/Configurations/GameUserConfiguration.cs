using MemeGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeGame.Infrastructure.Persistance.Configurations
{
    public class GameUserConfiguration : IEntityTypeConfiguration<GameUser>
    {
        public void Configure(EntityTypeBuilder<GameUser> builder)
        {
            builder.Property(t => t.GameId)
                .IsRequired();
        }
    }
}
