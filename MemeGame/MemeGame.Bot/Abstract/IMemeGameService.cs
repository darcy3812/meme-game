namespace MemeGame.Bot.Abstract
{
    public interface IMemeGameService
    {
        Task<bool> UploadMemeAsync(MemoryStream stream);
    }
}
