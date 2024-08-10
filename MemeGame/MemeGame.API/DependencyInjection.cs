using Mapster;
using Mapster.Utils;
using MemeGame.API.Hubs;
using MemeGame.Application.Notifications;
using MemeGame.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

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

        public static WebApplication UseAPI(this WebApplication app)
        {
            app.MapHub<LobbyHub>("/hub/lobby");

            return app;
        }

    }
}
