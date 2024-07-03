using Sync.Services.Interfaces;

namespace Sync.Services
{
    internal class ConsoleLogger : IConsoleLogger
    {
        public ConsoleLogger()
        {
                
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
