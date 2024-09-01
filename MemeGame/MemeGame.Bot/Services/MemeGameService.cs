using MemeGame.Bot.Abstract;

namespace MemeGame.Bot.Services
{
    public class MemeGameService : IMemeGameService
    {
        private readonly HttpClient _client;

        public MemeGameService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> UploadMemeAsync(MemoryStream stream)
        {
            var res = await _client.PostAsync("/upload", new StreamContent(stream));

            return res.IsSuccessStatusCode;
        }
    }
}
