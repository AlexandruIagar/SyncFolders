namespace Sync.Models
{
    internal class FolderStructure
    {
        public FolderStructure(string path)
        {
            Files = new List<SyncFileInfo>();
            Path = path;
        }

        public void AddFileInfo(bool isDirectory, string path, string hash)
        {
            var partialPath = path.Remove(0, this.Path.Length);

            Files.Add(new SyncFileInfo
            {
                IsDirectory = isDirectory,
                Path = path,
                PartialPath = partialPath,
                Hash = hash
            });
        }

        public List<SyncFileInfo> Files { get; private set; }

        public string Path { get; private set; }
    }
}
