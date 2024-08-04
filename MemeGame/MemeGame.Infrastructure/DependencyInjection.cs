using MemeGame.Application.Games;
using MemeGame.Application.UsersInfo;
using MemeGame.Infrastructure.Games;
using MemeGame.Infrastructure.Persistance;
using MemeGame.Infrastructure.UsersInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MemeGame.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserInfo, UserInfo>();

            return services;
        }

    }
}
