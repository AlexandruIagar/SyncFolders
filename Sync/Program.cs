using Microsoft.Extensions.DependencyInjection;
using Sync.Helpers;
using Sync.Services.Interfaces;
using System.Timers;

namespace MyApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                throw new Exception("Must have 3 args.");
            }

            var sourceFolderPath = args[0];
            var destinationPath = args[1];
            var intervalInSeconds = Convert.ToInt32(args[2]);
            var logFilePath = args[3];

            var services = ServcicesHelper.CreateServices(logFilePath, sourceFolderPath, destinationPath, intervalInSeconds);

            var runner = services.GetRequiredService<ISyncRunner>();

            runner.Run();
        }
    }
}