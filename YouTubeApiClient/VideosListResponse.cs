using System;

namespace YouTube
{
    public class RootObject : ListPageResponse<Video> { }

    public class Video
    {
        public string Id { get; set; }
        public VideoSnippet Snippet { get; set; }
        public ContentDetails ContentDetails { get; set; }
        public Status Status { get; set; }
        public Statistics Statistics { get; set; }
        public Player Player { get; set; }
        public TopicDetails TopicDetails { get; set; }
        public RecordingDetails RecordingDetails { get; set; }
        public FileDetails FileDetails { get; set; }
        public ProcessingDetails ProcessingDetails { get; set; }
        public Suggestions Suggestions { get; set; }
        public LiveStreamingDetails LiveStreamingDetails { get; set; }
    }

    public class VideoSnippet
    {
        public DateTime PublishedAt { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Thumbnails Thumbnails { get; set; }
        public string ChannelTitle { get; set; }
        public string[] Tags { get; set; }
        public string CategoryId { get; set; }
        public string LiveBroadcastContent { get; set; }
        public string DefaultLanguage { get; set; }
        public Localized Localized { get; set; }
        public string DefaultAudioLanguage { get; set; }
    }

    public class Thumbnails
    {
        public Thumbnail Default { get; set; }
        public Thumbnail Medium { get; set; }
        public Thumbnail High { get; set; }
        public Thumbnail Standard { get; set; }
        public Thumbnail Maxres { get; set; }

        public class Thumbnail
        {
            public string Url { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }
    }

    public class Localized
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ContentDetails
    {
        public string Duration { get; set; }
        public string Dimension { get; set; }
        public string Definition { get; set; }
        public string Caption { get; set; }
        public bool LicensedContetn { get; set; }
        public RegionRestriction RegionRestriction { get; set; }
        public ContentRating ContentRating { get; set; }
        public string Projection { get; set; }
        public bool HasCustomThumbnail { get; set; }
    }

    public class RegionRestriction
    {
        public string[] Allowed { get; set; }
        public string[] Blocked { get; set; }
    }

    public class ContentRating
    {
        public string AcbRating { get; set; }
        public string AgcomRating { get; set; }
        public string AnatelRating { get; set; }
        public string BbfcRating { get; set; }
        public string BfvcRating { get; set; }
        public string BmukkRating { get; set; }
        public string CatvRating { get; set; }
        public string CatvfrRating { get; set; }
        public string CbfcRating { get; set; }
        public string CccRating { get; set; }
        public string CceRating { get; set; }
        public string ChfilmRating { get; set; }
        public string ChvrsRating { get; set; }
        public string CicfRating { get; set; }
        public string CnaRating { get; set; }
        public string CncRating { get; set; }
        public string CsaRating { get; set; }
        public string CscfRating { get; set; }
        public string CzfilmRating { get; set; }
        public string DjctqRating { get; set; }
        public string[] DjctqRatingReasons { get; set; }
        public string EcbmctRating { get; set; }
        public string EefilmRating { get; set; }
        public string EgfilmRating { get; set; }
        public string EirinRating { get; set; }
        public string FcbmRating { get; set; }
        public string FcoRating { get; set; }
        public string FmocRating { get; set; }
        public string FpbRating { get; set; }
        public string[] FpbRatingReasons { get; set; }
        public string FskRating { get; set; }
        public string GrfilmRating { get; set; }
        public string IcaaRating { get; set; }
        public string IfcoRating { get; set; }
        public string IlfilmRating { get; set; }
        public string IncaaRating { get; set; }
        public string KfcbRating { get; set; }
        public string KijkwijzerRating { get; set; }
        public string KmrbRating { get; set; }
        public string LsfRating { get; set; }
        public string MccaaRating { get; set; }
        public string MccypRating { get; set; }
        public string McstRating { get; set; }
        public string MdaRating { get; set; }
        public string MedietilsynetRating { get; set; }
        public string MekuRating { get; set; }
        public string MibacRating { get; set; }
        public string MocRating { get; set; }
        public string MoctwRating { get; set; }
        public string MpaaRating { get; set; }
        public string MpaatRating { get; set; }
        public string MtrcbRating { get; set; }
        public string NbcRating { get; set; }
        public string NbcplRating { get; set; }
        public string NfrcRating { get; set; }
        public string NfvcbRating { get; set; }
        public string NkclvRating { get; set; }
        public string OflcRating { get; set; }
        public string PefilmRating { get; set; }
        public string RcnofRating { get; set; }
        public string ResorteviolenciaRating { get; set; }
        public string RtcRating { get; set; }
        public string RteRating { get; set; }
        public string RussiaRating { get; set; }
        public string SkfilmRating { get; set; }
        public string SmaisRating { get; set; }
        public string SmsaRating { get; set; }
        public string TvpgRating { get; set; }
        public string YtRating { get; set; }
    }

    public class Status
    {
        public string UploadStatus { get; set; }
        public string FailureReason { get; set; }
        public string RejectionReason { get; set; }
        public string PrivacyStatus { get; set; }
        public DateTime PublishAt { get; set; }
        public string License { get; set; }
        public bool Embeddable { get; set; }
        public bool PublicStatsViewable { get; set; }
    }

    public class Statistics
    {
        public long ViewCount { get; set; }
        public long LikeCount { get; set; }
        public long DislikeCount { get; set; }
        public long FavoriteCount { get; set; }
        public long CommentCount { get; set; }
    }

    public class Player
    {
        public string EmbedHtml { get; set; }
        public long EmbedHeight { get; set; }
        public long EmbedWidth { get; set; }
    }

    public class TopicDetails
    {
        public string[] TopicIds { get; set; }
        public string[] RelevantTopicIds { get; set; }
        public string[] TopicCategories { get; set; }
    }

    public class RecordingDetails
    {
        public string[] RecordingData { get; set; }
    }

    public class FileDetails
    {
        public string FileName { get; set; }
        public ulong FileSize { get; set; }
        public string FileType { get; set; }
        public string Container { get; set; }
        public VideoStream[] VideoStreams { get; set; }
        public AudioStream[] AudioStreams { get; set; }
        public ulong DurationMs { get; set; }
        public ulong BitrateBps { get; set; }
        public string CreationTime { get; set; }
    }

    public class VideoStream
    {
        public uint WidthPixels { get; set; }
        public uint HeightPixels { get; set; }
        public double FrameRateFps { get; set; }
        public double AspectRatio { get; set; }
        public string Codec { get; set; }
        public ulong BitrateBps { get; set; }
        public string Rotation { get; set; }
        public string Vendor { get; set; }
    }

    public class AudioStream
    {
        public uint ChannelCount { get; set; }
        public string Codec { get; set; }
        public ulong BitrateBps { get; set; }
        public string Vendor { get; set; }
    }

    public class ProcessingDetails
    {
        public string ProcessingStatus { get; set; }
        public ProcessingProgress ProcessingProgress { get; set; }
        public string ProcessingFailureReason { get; set; }
        public string PileDetailsAvailability { get; set; }
        public string ProcessingIssuesAvailability { get; set; }
        public string TagSuggestionsAvailability { get; set; }
        public string EditorSuggestionsAvailability { get; set; }
        public string ThumbnailsAvailability { get; set; }
    }

    public class ProcessingProgress
    {
        public ulong PartsTotal { get; set; }
        public ulong PartsProcessed { get; set; }
        public ulong TimeLeftMs { get; set; }
    }

    public class Suggestions
    {
        public string[] ProcessingErrors { get; set; }
        public string[] ProcessingWarnings { get; set; }
        public string[] ProcessingHints { get; set; }
        public TagSuggestion[] TagSuggestions { get; set; }
        public string[] EditorSuggestions { get; set; }
    }

    public class TagSuggestion
    {
        public string Tag { get; set; }
        public string CategoryRestricts { get; set; }
    }

    public class LiveStreamingDetails
    {
        public DateTime ActualStartTime { get; set; }
        public DateTime ActualEndTime { get; set; }
        public DateTime ScheduledStartTime { get; set; }
        public DateTime ScheduledEndTime { get; set; }
        public ulong ConcurrentViewers { get; set; }
        public string ActiveLiveChatId { get; set; }
    }
}