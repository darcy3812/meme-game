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
            services.AddScoped<INotificationSender, NotificationSender>();

            return services;
        }

        public static WebApplication UseAPI(this WebApplication app)
        {
            app.MapHub<GameHub>("/hub/gameHub");

            return app;
        }

    }
}
