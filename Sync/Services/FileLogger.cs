using Sync.Services.Interfaces;

namespace Sync.Services
{
    internal class FileLogger : IFileLogger
    {

        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            EnsureLogFileExists();

            using (var stream = new StreamWriter(_filePath, true))
            {
                stream.WriteLine(message);
            }
        }

        private void EnsureLogFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }
    }
}
