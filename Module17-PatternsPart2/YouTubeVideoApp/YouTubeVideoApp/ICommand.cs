using System.Threading.Tasks;

namespace YouTubeVideoApp
{
    /// <summary>
    /// Command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes command.
        /// </summary>
        /// <returns>Completed or failed Task</returns>
        Task Execute();
    }
}
