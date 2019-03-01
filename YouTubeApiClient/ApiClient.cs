using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace YouTube
{
    public class ApiClient
    {
        public int RequestDelay { get; set; }

        public int QuotaUsage { get; private set; }

        private readonly string ytApiUrl;
        private readonly string key;


        private readonly Dictionary<string, string> videosParameters = new Dictionary<string, string>
        {
            { "part", "statistics,snippet" },
        };

        private readonly JsonSerializerSettings jsonSerializerSettings;


        public ApiClient(string key, int requestDelay = 50)
        {
            this.key = key;
            RequestDelay = requestDelay;
        }

        private ApiClient()
        {
            ytApiUrl = "https://www.googleapis.com/youtube/v3";
            jsonSerializerSettings = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        }


        //public List<CommentThreads> GetAllComments(string videoId, CommentThreadsParameters parameters, Action<int, int> progressChanged = null)
        //{
        //    CommentThreads response = GetCommentThreads(videoId, parameters);
        //    List<CommentThreads> commentPages = new List<CommentThreads>() { response };

        //    string token = response.NextPageToken;
        //    int doneTopLevels = response.Items.Count;
        //    int doneReplies = GetRepliesCount(response);
        //    progressChanged?.Invoke(doneTopLevels, doneReplies);

        //    Thread.Sleep(RequestDelay);

        //    while (!string.IsNullOrWhiteSpace(token))
        //    {
        //        response = GetCommentThreads(videoId, parameters);
        //        //response.PrevPageToken = token;
        //        commentPages.Add(response);
        //        token = response.NextPageToken;

        //        if (progressChanged != null)
        //        {
        //            doneTopLevels += response.Items.Count;
        //            doneReplies += GetRepliesCount(response);

        //            progressChanged.Invoke(doneTopLevels, doneReplies);
        //        }

        //        Thread.Sleep(RequestDelay);
        //    }

        //    return commentPages;
        //}

        //public CommentThreads GetCommentThreads(string videoId, CommentThreadsParameters parameters)
        //{
        //    var id = new Dictionary<string, string>
        //    {
        //        { "videoId", videoId },
        //    };

        //    QuotaUsage += parameters.QuotaCost;

        //    return ApiRequest<CommentThreads>("commentThreads", id, parameters.ToDictionary());
        //}

        public CommentThreads GetCommentThreadsRelatedToChannelId(string channelId, CommentThreadsParameters parameters)
        {
            return GetCommentThreads("allThreadsRelatedToChannelId", channelId, parameters);
        }


        public CommentThreads GetCommentThreadsByChannelId(string channelId, CommentThreadsParameters parameters)
        {
            return GetCommentThreads(nameof(channelId), channelId, parameters);
        }


        public CommentThreads GetCommentThreadsById(string id, CommentThreadsParameters parameters)
        {
            return GetCommentThreads(nameof(id), id, parameters);
        }

        public CommentThreads GetCommentThreadsById(IEnumerable<string> ids, CommentThreadsParameters parameters)
        {
            return GetCommentThreadsById(string.Join(",", ids), parameters);
        }


        public CommentThreads GetCommentThreadsByVideoId(string videoId, CommentThreadsParameters parameters)
        {
            return GetCommentThreads(nameof(videoId), videoId, parameters);
        }

        private CommentThreads GetCommentThreads(string filterName, string filterValue, CommentThreadsParameters parameters)
        {
            return ApiRequest<CommentThreads>("commentThreads", filterName, filterValue, parameters);
        }

        //public CommentListResponse GetCommentReplies(string videoId, string commentId, string nextPageToken = null)
        //{
        //    var parameters = new Dictionary<string, string>
        //    {
        //        { "videoId", videoId },
        //        { "parentId", commentId }
        //    };

        //    if (nextPageToken != null)
        //    {
        //        parameters.Add("pageToken", nextPageToken);
        //    }

        //    return ApiRequest<CommentListResponse>("comments", parameters, commentsParameters);
        //}

        //public List<Comment> GetAllCommentReplies(string videoId, string commentId)
        //{
        //    CommentListResponse response = GetCommentReplies(videoId, commentId);
        //    List<Comment> replies = new List<Comment>(response.Items.Select(i => i.snippet));

        //    string token = response.NextPageToken;

        //    while (!string.IsNullOrWhiteSpace(token))
        //    {
        //        response = GetCommentReplies(videoId, commentId, token);
        //        replies.AddRange(response.Items.Select(i => i.snippet));
        //        token = response.NextPageToken;

        //        Thread.Sleep(RequestDelay);
        //    }

        //    return replies;
        //}

        public RootObject GetVideosById(string id, IRequestParameters parameters)
        {
            return ApiRequest<RootObject>("videos", nameof(id), id, parameters);
        }

        public RootObject GetVideosById(IEnumerable<string> ids, IRequestParameters parameters)
        {
            return GetVideosById(string.Join(",", ids), parameters);
        }

        #region Helpers

        private int GetRepliesCount(CommentThreads response)
        {
            int replyCount = 0;

            foreach (CommentThread item in response.Items)
            {
                replyCount += item.Snippet.TotalReplyCount;
            }

            return replyCount;
        }

        private T ApiRequest<T>(string path, string filterName, string filterValue, IRequestParameters parameters) where T : Response
        {
            string url = CreateURL(path, new Dictionary<string, string>(parameters.ToDictionary()) { { filterName, filterValue } });
            var request = (HttpWebRequest)WebRequest.Create(url);
            string responseString;

            using (var webResponse = request.GetResponse())
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        responseString = streamReader.ReadToEnd();
                    }
                }
            }

            var response = JsonConvert.DeserializeObject<T>(responseString, jsonSerializerSettings);
            response.Request = url;
            QuotaUsage += parameters.QuotaCost;
            return response;
        }

        private string CreateURL(string path, params Dictionary<string, string>[] parameters)
        {
            string url = $"{ytApiUrl}/{path}?key={key}";

            foreach (Dictionary<string, string> dictionary in parameters)
            {
                foreach (KeyValuePair<string, string> item in dictionary)
                {
                    url += $"&{item.Key}={item.Value}";
                }
            }

            return url;
        }

        #endregion
    }
}
