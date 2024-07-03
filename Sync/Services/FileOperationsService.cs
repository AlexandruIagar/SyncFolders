using Sync.Models;
using Sync.Services.Interfaces;
using Sync.Models.Enums;

namespace Sync.Services
{
    internal class FileOperationsService : IFileOperationsService
    {
        private readonly ILogger _logger;

        public FileOperationsService(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateFile(SyncFileInfo file, string destinationFolderPath)
        {
            var desinationPath = destinationFolderPath + file.PartialPath;
            if (file.IsDirectory)
            {
                Directory.CreateDirectory(desinationPath);

                _logger.Log(FileOperationType.CrateDirectory, desinationPath);

                return;
            }

            File.Copy(file.Path, desinationPath);

            _logger.Log(FileOperationType.CopyFile, desinationPath);
        }

        public void DeleteFile(SyncFileInfo file)
        {
            if (file.IsDirectory && Directory.Exists(file.Path))
            {
                Directory.Delete(file.Path);

                _logger.Log(FileOperationType.DeleteDirectory, file.Path);

                return;
            }

            if (File.Exists(file.Path))
            {
                File.Delete(file.Path);

                _logger.Log(FileOperationType.DeleteFile, file.Path);
            }
        }

        public void CopyFile(SyncFileInfo file, string destinationFolderPath)
        {
            var desinationPath = Path.Combine(destinationFolderPath, file.PartialPath);
            File.Delete(desinationPath);

            File.Copy(file.Path, desinationPath);

            _logger.Log(FileOperationType.CopyFile, desinationPath);
        }
    }
}
