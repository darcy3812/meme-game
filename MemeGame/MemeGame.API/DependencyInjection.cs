using MemeGame.API.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemeGame.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSignalR();

            return services;
        }

        public static WebApplication UseAPI(this WebApplication app)
        {
            app.MapHub<GameHub>("/gameHub");

            return app;
        }

    }
}
