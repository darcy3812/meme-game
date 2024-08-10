using MemeGame.Application.FileStorage;
using MemeGame.Infrastructure.FileStorages;
using MemeGame.Infrastructure.StorageProviders.Local.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemeGame.Infrastructure.StorageProviders.Local
{
    public class LocalStorage : IStorageProvider
    {
        private readonly LocalStorageConfiguration _config;

        public LocalStorage(IOptions<LocalStorageConfiguration> config)
        {
            _config = config.Value;
        }

        public string ProviderName => StorageTypes.Local;

        public Task<bool> DeleteAsync(string id)
        {
            if (!File.Exists(GetFilePath(id)))
            {
                return Task.FromResult(false);
            }

            File.Delete(id);

            return Task.FromResult(true);
        }

        public async Task<Stream> GetContentsAsync(string id)
        {
            var filePath = GetFilePath(id);
            if (!File.Exists(filePath))
            {
                throw new Exception("Файл не найден");
            }

            var fileContent = await File.ReadAllBytesAsync(filePath);

            return new MemoryStream(fileContent);
        }

        public async Task<string> SaveAsync(IFileSummary fileSummary, Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var filePath = GetFilePath(fileSummary);

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                await stream.CopyToAsync(fs);

                return GetFileName(fileSummary);
            }
        }

        private string GetFilePath(IFileSummary fileSummary)
        {
            var fileName = GetFileName(fileSummary);
            var currentFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var folderPath = Path.Combine(currentFolder, _config.FolderPath);
            var path = Directory.CreateDirectory(folderPath);
            var filePath = Path.Combine(folderPath, fileName);

            return filePath;
        }

        private static string GetFileName(IFileSummary fileSummary)
        {
            return $"{fileSummary.Name}.{fileSummary.Extension}";
        }

        private string GetFilePath(string file)
        {
            var parts = file.Split('.');
            var fileSummary = new FileSummary
            {
                Extension = parts[^1],
                Name = parts[0]
            };

            return GetFilePath(fileSummary);            
        }
    }
}
