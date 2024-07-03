using Microsoft.Extensions.DependencyInjection;
using Sync.Services.Interfaces;
using Sync.Services;

namespace Sync.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddSyncServices(this ServiceCollection serviceCollection, string logFilePath, string sourceFolderPath, string desinationFolderPath, int intervalInSeconds)
        {
            serviceCollection
                .AddTransient<ISyncService, SyncService>()
                .AddTransient<IFileOperationsService, FileOperationsService>()
                .AddTransient<IFileLogger, FileLogger>(sp => new FileLogger(logFilePath))
                .AddTransient<IConsoleLogger, ConsoleLogger>()
                .AddTransient<ILogger, Logger>()
                .AddTransient<ISyncRunner, SyncRunner>(sp =>
                {
                    var syncService = sp.GetRequiredService<ISyncService>();

                    return new SyncRunner(sourceFolderPath, desinationFolderPath, intervalInSeconds, syncService);
                });

        }
    }
}
