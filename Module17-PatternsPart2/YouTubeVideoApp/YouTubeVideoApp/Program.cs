using System;

namespace YouTubeVideoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var videoUrl = "https://youtu.be/PLe7i_jK41g";
            var sender = new Sender();
            var receiver = new Receiver(videoUrl);

            sender.SetCommand(new GetVideoInformationCommand(receiver));
            sender.Run();

            sender.SetCommand(new DownloadVideoCommand(receiver));
            sender.Run();

            Console.ReadKey();
        }
    }
}
