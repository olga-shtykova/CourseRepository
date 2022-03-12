namespace MiniCalculator.Interfaces
{
    public interface ILogger
    {
        void LogError(string message);
        void LogEvent(string message);
    }
}
