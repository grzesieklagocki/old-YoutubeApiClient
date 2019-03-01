using System.Collections.Generic;

namespace YouTube
{
    public class CommentListResponse
    {
        public string NextPageToken { get; set; }
        public List<CommentSnippet> Items { get; set; }
    }
}
