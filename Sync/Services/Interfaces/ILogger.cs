using Sync.Models.Enums;

namespace Sync.Services.Interfaces
{
    internal interface ILogger
    {
        void Log(FileOperationType operationType, string path);
    }
}
