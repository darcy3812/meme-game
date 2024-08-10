using MemeGame.Application.FileStorage;
using MemeGame.Application.Games;
using MemeGame.Application.Users;
using MemeGame.Application.UsersInfo;
using MemeGame.Infrastructure.FileStorages;
using MemeGame.Infrastructure.Games;
using MemeGame.Infrastructure.Persistance;
using MemeGame.Infrastructure.StorageProviders;
using MemeGame.Infrastructure.StorageProviders.Local;
using MemeGame.Infrastructure.StorageProviders.Local.Configuration;
using MemeGame.Infrastructure.StorageProviders.S3;
using MemeGame.Infrastructure.StorageProviders.S3.Configuration;
using MemeGame.Infrastructure.Users;
using MemeGame.Infrastructure.UsersInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using System;

namespace MemeGame.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserInfo, UserInfo>();
            services.AddScoped<IUserService, UsersService>();
            ConfigureStorage(configuration, services);

            return services;
        }

        private static void ConfigureStorage(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IFileStorage, FileStorage>();
            var config = configuration.GetSection(StorageConfiguration.SectionName).Get<StorageConfiguration>();

            if (config == null)
            {
                throw new InvalidOperationException($"Section {StorageConfiguration.SectionName} not found in appsettings.json");
            }
            switch (config.StorageProvider)
            {
                case StorageTypes.S3:
                    ConfigureS3(configuration, services);
                    break;
                case StorageTypes.Local:
                    ConfigureLocalStorage(configuration, services);
                    break;
            }
        }

        private static void ConfigureLocalStorage(IConfiguration configuration, IServiceCollection services)
        {
            var storageSection = configuration.GetSection(StorageConfiguration.SectionName);
            services.Configure<LocalStorageConfiguration>(storageSection.GetSection(LocalStorageConfiguration.SectionName));

            services.AddScoped<IStorageProvider, LocalStorage>();
        }

        private static void ConfigureS3(IConfiguration configuration, IServiceCollection services)
        {
            var storageSection = configuration.GetSection(StorageConfiguration.SectionName);
            var config = storageSection.GetSection(S3Configuration.SectionName).Get<S3Configuration>();
            if (config == null)
            {
                throw new InvalidOperationException($"Section {S3Configuration.SectionName} not found in appsettings.json");
            }
            services.Configure<S3Configuration>(storageSection.GetSection(StorageConfiguration.SectionName));

            services.AddSingleton((sp) => new MinioClient()
                .WithEndpoint(config.Endpoint)
                .WithRegion(config.Region)
                .WithCredentials(config.Key, config.Secret)
                .Build());
            services.AddScoped<IStorageProvider, S3Storage>();
        }
    }
}
