using MemeGame.Application.FileStorage;
using MemeGame.Infrastructure.StorageProviders.S3.Configuration;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MemeGame.Infrastructure.StorageProviders.S3
{
    public class S3Storage : IStorageProvider
    {
        private readonly IMinioClient _minioClient;
        private readonly S3Configuration _config;

        public S3Storage(IMinioClient minioClient, IOptions<S3Configuration> config)
        {
            _minioClient = minioClient;
            _config = config.Value;
        }

        public string ProviderName => StorageTypes.S3;

        public async Task<bool> DeleteAsync(string id)
        {
            var args = new RemoveObjectArgs()
                .WithBucket(_config.BucketName)
                .WithObject(id);
            await _minioClient.RemoveObjectAsync(args);

            return true;
        }

        public async  Task<Stream> GetContentsAsync(string id)
        {
            var downloadStream = new MemoryStream();
            var args = new GetObjectArgs()
                    .WithBucket(_config.BucketName)
                    .WithObject(id)
                    .WithCallbackStream(s =>
                    {
                        s.CopyTo(downloadStream);
                        downloadStream.Seek(0, SeekOrigin.Begin);
                    });

            await _minioClient.GetObjectAsync(args);

            return downloadStream;
        }

        public async Task<string> SaveAsync(IFileSummary fileSummary, Stream stream)
        {
            var objectName = GetObjectName(fileSummary);
            var putObjectArgs = new PutObjectArgs()
                                        .WithBucket(_config.BucketName)
                                        .WithObject(objectName)
                                        .WithStreamData(stream)
                                        .WithObjectSize(stream.Length);
            await _minioClient.PutObjectAsync(putObjectArgs);

            fileSummary.Name = objectName;

            return fileSummary.Name;
        }

        private static string GetObjectName(IFileSummary fileSummary)
        {
            return fileSummary.Name ?? Guid.NewGuid().ToString();
        }
    }
}
