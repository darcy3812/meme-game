using MemeGame.Bot.Services;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace MemeGame.Bot
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBot(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BotConfiguration>(configuration.GetSection("BotConfiguration"));

            services.AddHttpClient("telegram_bot_client").RemoveAllLoggers()
                    .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                    {
                        BotConfiguration botConfiguration = sp.GetService<IOptions<BotConfiguration>>()?.Value;
                        ArgumentNullException.ThrowIfNull(botConfiguration);
                        TelegramBotClientOptions options = new(botConfiguration.BotToken);
                        return new TelegramBotClient(options, httpClient);
                    });
            services.ConfigureTelegramBotMvc();
            services.AddScoped<UpdateHandler>();

            return services;
        }
    }
}
