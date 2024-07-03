using Microsoft.Extensions.DependencyInjection;
using Sync.Extensions;

namespace Sync.Helpers
{
    internal class ServcicesHelper
    {
        internal static ServiceProvider CreateServices(string logFilePath, string sourceFolderPath, string desinationFolderPath, int intervalInSeconds)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSyncServices(logFilePath, sourceFolderPath, desinationFolderPath, intervalInSeconds);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
