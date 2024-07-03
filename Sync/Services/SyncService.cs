using Sync.Models;
using Sync.Services.Interfaces;
using System.IO;
using System.Security.Cryptography;

namespace Sync.Services
{
    internal class SyncService : ISyncService
    {
        private readonly IFileOperationsService _fileOperationsService;

        public SyncService(IFileOperationsService fileOperationsService)
        {
            _fileOperationsService = fileOperationsService;
        }

        public void SyncFolders(string sourceFolderPath, string destinationFolderPath)
        {
            var sourceFileFolderStructure = GetFolderStructure(sourceFolderPath);
            var destinationFoldeStructure = GetFolderStructure(destinationFolderPath);

            var filesToCreate = sourceFileFolderStructure.Files
                .Where(sf => !destinationFoldeStructure.Files.Any(df => df.PartialPath == sf.PartialPath))
                .ToList();

            var fileSToDelete = destinationFoldeStructure.Files
                .Where(sf => !sourceFileFolderStructure.Files.Any(df => df.PartialPath == sf.PartialPath))
                .ToList();

            var filesToCopy = sourceFileFolderStructure.Files
                .Where(sf => !sf.IsDirectory && destinationFoldeStructure.Files.Any(df => !df.IsDirectory && df.PartialPath == sf.PartialPath && df.Hash != sf.Hash))
                .ToList();

            filesToCreate.ForEach(f => _fileOperationsService.CreateFile(f, destinationFolderPath));
            fileSToDelete.ForEach(f => _fileOperationsService.DeleteFile(f));
            filesToCopy.ForEach(f => _fileOperationsService.CopyFile(f, destinationFolderPath));
        }

        private FolderStructure GetFolderStructure(string directoryPath)
        {
            var result = new FolderStructure(directoryPath);

            var filePaths = Directory.GetFileSystemEntries(directoryPath, "*", SearchOption.AllDirectories);

            foreach (var filePath in filePaths)
            {
                var isDirectory = Directory.Exists(filePath);
                if(isDirectory)
                {
                    result.AddFileInfo(isDirectory, filePath, string.Empty);

                    continue;
                }

                var fileHash = GetFileHash(filePath);
                result.AddFileInfo(isDirectory, filePath, fileHash);
            }

            return result;
        }

        private string GetFileHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        
    }
}
