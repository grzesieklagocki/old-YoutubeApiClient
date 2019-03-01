using System;
using System.Linq;

namespace YouTube
{
    public static class YouTubeHelper
    {
        public static string YouTubeUrl => "https://www.youtube.com";


        public static string GetVideoIDFromUrl(string url) => GetParameterFromUrl("v", url);

        public static string GetVideoUrl(string videoId) => $"{YouTubeUrl}/watch?v={videoId}";

        public static string GetChannelUrl(string channelId) => $"{YouTubeUrl}/channel/{channelId}";

        public static string GetCommentUrl(string videoId, string commentId) => $"{GetVideoUrl(videoId)}&lc={commentId}";

        public static bool ValidateVideoId(string id)
        {
            return !(string.IsNullOrWhiteSpace(id) || id.Length != 11 && id.Any(c => !char.IsLetterOrDigit(c)));
        }

        public static string GetParameterFromUrl(string parameter, string url, StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            return url.
                Split('?')[1]?.
                Split('&')?.
                FirstOrDefault(s => s.StartsWith($"{parameter}=", stringComparison))?.
                Substring(parameter.Length + 1);
        }
    }
}
