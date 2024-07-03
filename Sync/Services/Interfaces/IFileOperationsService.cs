using Sync.Models;

namespace Sync.Services.Interfaces
{
    internal interface IFileOperationsService
    {
        void CreateFile(SyncFileInfo file, string destinationFolderPath);

        void DeleteFile(SyncFileInfo file);

        void CopyFile(SyncFileInfo file, string destinationFolderPath);
    }
}
