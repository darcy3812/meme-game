using MemeGame.API.Hubs;
using MemeGame.Common.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemeGame.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddScoped<INotificationSender, NotificationSender>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });
            return services;
        }

        public static WebApplication UseAPI(this WebApplication app)
        {
            app.UseCors();
            app.MapHub<GameHub>("/gameHub");

            return app;
        }

    }
}
