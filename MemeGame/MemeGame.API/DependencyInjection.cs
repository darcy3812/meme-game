using Mapster;
using Mapster.Utils;
using MemeGame.API.Hubs;
using MemeGame.Application.Notifications;
using MemeGame.Domain;
using MemeGame.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MemeGame.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });
            services.AddSignalR(opt =>
            {
                opt.EnableDetailedErrors = true;
            });
            services.AddHttpContextAccessor();
            services.AddScoped<ILobbyNotificationSender, NotificationSender<LobbyHub>>();
            services.AddScoped<IGameNotificationSender, NotificationSender<GameHub>>();
            TypeAdapterConfig.GlobalSettings.ScanInheritedTypes(typeof(AssemblyMarker).Assembly);

            return services;
        }

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public static WebApplication UseAPI(this WebApplication app)
        {
            app.MapHub<LobbyHub>("/hub/lobby");

            return app;
        }

    }
}
