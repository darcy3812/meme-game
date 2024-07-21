using MemeGame.Domain;
using MemeGame.Domain.Games;
using Microsoft.EntityFrameworkCore;

namespace MemeGame.Infrastructure.Persistance
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GameUser> GameUsers { get; set; }
        public DbSet<Meme> Memes { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundAnswer> RoundAnswers { get; set; }
        public DbSet<GameSetting> GameSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
