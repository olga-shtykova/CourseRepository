using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace YouTubeVideoApp
{
    /// <summary>
    /// Command receiver.
    /// </summary>
    public class Receiver
    {
        public string VideoUrl { get; set; }

        /// <summary>
        /// Receiver constractor.
        /// </summary>
        /// <param name="videoUrl">YouTube Video URL.</param>
        public Receiver(string videoUrl)
        {
            VideoUrl = videoUrl;
        }

        /// <summary>
        /// Gets YouTube video's information.
        /// </summary>
        /// <returns></returns>
        public async Task GetVideoInfo()
        {
            var youtubeClient = new YoutubeClient();
            var trackManifest = await youtubeClient.Videos.GetAsync(VideoUrl);

            Console.WriteLine($"Video title: {trackManifest.Title}");
            Console.WriteLine($"Video description: {trackManifest.Description}");
        }

        /// <summary>
        /// Downloads YouTube video.
        /// </summary>
        /// <returns></returns>
        public async Task DownloadVideo()
        {
            var outputFilePath = "video.mp4";
            var youtubeClient = new YoutubeClient();
            await youtubeClient.Videos.DownloadAsync(VideoUrl, outputFilePath,
                builder => builder.SetPreset(ConversionPreset.UltraFast));
        }
    }
}
