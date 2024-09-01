using MemeGame.Application.FileStorage;
using MemeGame.Infrastructure.FileStorages;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace MemeGame.Bot.Services;

public class UpdateHandler(ITelegramBotClient bot, ILogger<UpdateHandler> logger, IFileStorage fileStorage) : IUpdateHandler
{
    private readonly ITelegramBotClient _bot = bot;
    private readonly ILogger<UpdateHandler> _logger = logger;
    private readonly IFileStorage _fileStorage = fileStorage;

    public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
    {
        _logger.LogInformation("HandleError: {Exception}", exception);
        // Cooldown in case of network connection error
        if (exception is RequestException)
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await (update switch
        {
            { Message: { } message } => OnMessage(message),
            _ => UnknownUpdateHandlerAsync(update)
        });
    }

    private async Task OnMessage(Message msg)
    {
        _logger.LogInformation("Receive message type: {MessageType}", msg.Type);

        if (msg.Photo == null || msg.Photo.Length == 0)
        {
            await _bot.SendTextMessageAsync(msg.Chat.Id, "Отправь картинку");
            return;
        }

        foreach (var item in msg.Photo)
        {
            using (var ms = new MemoryStream())
            {
                var file = await TelegramBotClientExtensions.GetInfoAndDownloadFileAsync(_bot, item.FileId, ms);
                ms.Seek(0, SeekOrigin.Begin);
                await _fileStorage.SaveAsync(new FileSummary
                {
                    Name = Guid.NewGuid().ToString(),
                    Extension = file.FilePath.Split('.')[^1]
                },
                ms);
            }
        }
    }

    private Task UnknownUpdateHandlerAsync(Update update)
    {
        _logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }
}
