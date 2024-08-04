using MemeGame.API.Hubs;
using MemeGame.Common.Notifications;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
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
            services.AddSignalR();
            services.AddHttpContextAccessor();
            services.AddScoped<INotificationSender<LobbyHub>, NotificationSender<LobbyHub>>();
            services.AddScoped<INotificationSender<GameHub>, NotificationSender<GameHub>>();

            return services;
        }

        public static WebApplication UseAPI(this WebApplication app)
        {
            app.MapHub<LobbyHub>("/hub/lobby");

            return app;
        }

    }
}
