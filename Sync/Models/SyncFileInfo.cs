namespace Sync.Models
{
    public class SyncFileInfo
    {
        public bool IsDirectory { get; set; }

        public string Path { get; set; }

        public string PartialPath { get; set; }

        public string Hash { get; set; }
    }
}
