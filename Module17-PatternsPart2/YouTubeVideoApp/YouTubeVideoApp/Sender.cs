namespace YouTubeVideoApp
{
    /// <summary>
    /// Command sender.
    /// </summary>
    public class Sender
    {
        ICommand _command;

        /// <summary>
        /// Sets a particular command.
        /// </summary>
        /// <param name="command">Command.</param>
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        /// <summary>
        /// Invokes command;s execution.
        /// </summary>
        public void Run()
        {
            _command.Execute();
        }
    }
}
