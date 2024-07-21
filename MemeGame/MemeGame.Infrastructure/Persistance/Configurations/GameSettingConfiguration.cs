using MemeGame.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeGame.Infrastructure.Persistance.Configurations
{
    public class GameSettingConfiguration : IEntityTypeConfiguration<GameSetting>
    {
        public void Configure(EntityTypeBuilder<GameSetting> builder)
        {
            builder.Property(t => t.MaxPoints)
                .IsRequired(false);

            builder.Property(t => t.MaxRounds)                
                .IsRequired(false);
        }
    }
}
