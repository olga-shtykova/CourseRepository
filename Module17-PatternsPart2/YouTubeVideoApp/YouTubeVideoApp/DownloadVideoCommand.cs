using System;
using System.Threading.Tasks;

namespace YouTubeVideoApp
{
    /// <summary>
    /// Download video Command.
    /// </summary>
    public class DownloadVideoCommand : ICommand
    {
        private readonly Receiver _receiver;

        /// <summary>
        /// DownloadVideoCommand constractor.
        /// </summary>
        /// <param name="receiver">Receiver.</param>
        public DownloadVideoCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        /// <inheritdoc/>
        public async Task Execute()
        {            
            await _receiver.DownloadVideo();
        }
    }
}
