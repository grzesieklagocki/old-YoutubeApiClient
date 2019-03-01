using System;
using System.Collections.Generic;

namespace YouTube
{
    public class Comment
    {
        public string AuthorDisplayName { get; set; }
        public string AuthorProfileImageUrl { get; set; }
        public string AuthorChannelUrl { get; set; }
        public AuthorChannelId AuthorChannelId { get; set; }
        public string ChannelId { get; set; }
        public string VideoId { get; set; }
        public string TextDisplay { get; set; }
        public string TextOriginal { get; set; }
        public string ParentId { get; set; }
        public bool CanRate { get; set; }
        public string ViewerRating { get; set; }
        public int LikeCount { get; set; }
        public string ModerationStatus { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class AuthorChannelId
    {
        public string Value { get; set; }
    }

    public class CommentSnippet
    {
        public string Etag { get; set; }
        public string Id { get; set; }
        public Comment Snippet { get; set; }
    }

    public class CommentDetails
    {
        public string ChannelId { get; set; }
        public string VideoId { get; set; }
        public CommentSnippet TopLevelComment { get; set; }
        public bool CanReply { get; set; }
        public int TotalReplyCount { get; set; }
        public bool IsPublic { get; set; }
    }

    public class Replies
    {
        public List<Comment> Comments { get; set; }
    }

    public class CommentThread
    {
        public string Etag { get; set; }
        public string Id { get; set; }
        public CommentDetails Snippet { get; set; }
        public Replies Replies { get; set; }
    }

    public class CommentThreads : ListPageResponse<CommentThread> { }


    public abstract class ListPageResponse<TItem> : ListResponse<TItem>
    {
        public string PageToken => YouTubeHelper.GetParameterFromUrl("pageToken", Request); 
        public string NextPageToken { get; set; }
        public string PrevPageToken { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public abstract class ListResponse<TItem> : Response
    {
        public List<TItem> Items { get; set; }
    }

    public abstract class Response
    {
        public string Request { get; set; }
        public string Etag { get; set; }
    }

    public class PageInfo
    {
        public int TotalResults { get; set; }
        public int ResultsPerPage { get; set; }
    }
}
