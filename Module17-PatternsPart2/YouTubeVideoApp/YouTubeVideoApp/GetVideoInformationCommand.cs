using System.Threading.Tasks;

namespace YouTubeVideoApp
{
    /// <summary>
    /// Get video information Command.
    /// </summary>
    public class GetVideoInformationCommand : ICommand
    {
        private readonly Receiver _receiver;

        /// <summary>
        /// GetVideoInformationCommand constractor.
        /// </summary>
        /// <param name="receiver">Receiver.</param>
        public GetVideoInformationCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        /// <inheritdoc/>
        public async Task Execute()
        {
            await _receiver.GetVideoInfo();
        }
    }
}
