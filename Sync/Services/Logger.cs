using Sync.Helpers;
using Sync.Models.Enums;
using Sync.Services.Interfaces;

namespace Sync.Services
{
    internal class Logger : ILogger
    {
        private readonly IFileLogger _fileLogger;
        private readonly IConsoleLogger _consoleLogger;

        public Logger(IFileLogger fileLogger, IConsoleLogger consoleLogger)
        {
            _fileLogger = fileLogger;
            _consoleLogger = consoleLogger;
        }

        public void Log(FileOperationType operationType, string path)
        {
            var now = DateTimeOffset.UtcNow;
            var formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss,fff");
            var operation = operationType.GetDisplayName();
            var message = string.Format("[{0}] {1} to {2}", formattedDate, operation, path);

            _fileLogger.Log(message);
            _consoleLogger.Log(message);
        }
    }
}
