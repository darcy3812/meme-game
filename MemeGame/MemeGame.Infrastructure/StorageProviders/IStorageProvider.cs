using MemeGame.Application.FileStorage;
using System.IO;
using System.Threading.Tasks;

namespace MemeGame.Infrastructure.StorageProviders
{
    public interface IStorageProvider
    {
        string ProviderName { get; }

        Task<string> SaveAsync(IFileSummary fileSummary, Stream stream);

        Task<Stream> GetContentsAsync(string id);

        Task<bool> DeleteAsync(string id);
    }
}
