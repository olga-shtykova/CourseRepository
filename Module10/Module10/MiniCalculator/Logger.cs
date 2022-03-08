using MiniCalculator.Interfaces;

namespace MiniCalculator
{
    public class Logger : ILogger
    {
        public void LogError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }

        public void LogEvent(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
    }
}
