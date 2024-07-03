namespace Sync.Services.Interfaces
{
    internal interface ISyncService
    {
        void SyncFolders(string sourceFolderPath, string destinationFolderPath);
    }
}
