using MemeGame.Application.FileStorage;
using MemeGame.Domain;
using MemeGame.Infrastructure.Persistance;
using MemeGame.Infrastructure.StorageProviders;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemeGame.Infrastructure.FileStorages
{
    public class FileStorage : IFileStorage
    {
        private readonly ApplicationContext _context;
        private readonly IStorageProvider _storageProvider;

        public FileStorage(ApplicationContext context, IStorageProvider storageProvider)
        {
            _context = context;
            _storageProvider = storageProvider;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var fileMeta = _context.FilesMetadata.First(f => f.Id == id);

            var result = await _storageProvider.DeleteAsync(fileMeta.IdInExternalStorage);
            if (!result)
            {
                return false;
            }

            _context.FilesMetadata.Remove(fileMeta);

            return true;
        }

        public async Task<IFileSummary> GetContentsAsync(int id)
        {
            var fileMeta = _context.FilesMetadata.First(f => f.Id == id);

            var stream = await _storageProvider.GetContentsAsync(fileMeta.IdInExternalStorage);
            return new FileSummary
            {
                Extension = fileMeta.Extension,
                Name = fileMeta.IdInExternalStorage,
                Stream = stream
            };
        }

        public async Task<IFileSummary> SaveAsync(IFileSummary fileSummary, Stream stream)
        {
            var result = await _storageProvider.SaveAsync(fileSummary, stream);
            fileSummary.Name = result;

            _context.FilesMetadata.Add(new FileMetadata
            {
                ExternalStorage = _storageProvider.ProviderName,
                IdInExternalStorage = result,
                Extension = fileSummary.Extension
            });

            await _context.SaveChangesAsync();

            return fileSummary;
        }
    }
}
