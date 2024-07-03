using Sync.Services.Interfaces;
using System.Timers;
using SystemTimers = System.Timers;

namespace Sync.Services
{
    internal class SyncRunner : ISyncRunner
    {
        private readonly SystemTimers.Timer _timer;
        private readonly string _sourceFolderPath;
        private readonly string _destinationFolderPath;
        private readonly ISyncService _syncService;

        public SyncRunner(string sourceFolderPath,
            string desitnationFolderPath,
            int intervalinSeconds,
            ISyncService syncService)
        {
            _timer = new SystemTimers.Timer(intervalinSeconds * 1000);
            _timer.Elapsed += Run;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            _sourceFolderPath = sourceFolderPath;
            _destinationFolderPath = desitnationFolderPath;
            _syncService = syncService;
        }

        public void Run()
        {
            while (true)
            {
                SyncFolders();
            }
        }

        private void Run(Object source, ElapsedEventArgs e)
        {
            SyncFolders();
        }

        private void SyncFolders()
        {
            try
            {
                _syncService.SyncFolders(_sourceFolderPath, _destinationFolderPath);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
