using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSoft.Messaging.Extensions;
using Ketabex.lib;
using Ketabex.Shared.Models;

namespace Ketabex.Shared.Api
{
    public class PostApi : BaseApi
    {
        public const string POSTS_OF_FOLLOWINGS_URL = SITE_BASE_API + "posts/followings";
        public const string POSTS_OF_LATEST_URL = SITE_BASE_API + "posts/latest";
        public const string POSTS_OF_TOP_URL = SITE_BASE_API + "posts/top";


        public void UpdatePostsOfMode(DataMode mode, bool showProgress = false)
        {
            var url = "";

            switch (mode)
            {
                case DataMode.Following:
                    url = POSTS_OF_FOLLOWINGS_URL;
                    break;
                case DataMode.Latest:
                    url = POSTS_OF_LATEST_URL;
                    break;
                case DataMode.Top:
                    url = POSTS_OF_TOP_URL;
                    break;
            }

            if (showProgress)
                GlobalUtil.NativeUtil.ShowMessage("صبر کنید");

            Task.Run(async () =>
            {
                var result = await Call(url, new NameValueCollection()
                {
                    {"lastUpdateId" , (Database.GetInstance().GetDbCon().Table<Post>().Any() ?
                    Database.GetInstance().GetDbCon().Table<Post>().Max(q=>q.Id) : -1).ToString()}
                });

                //if an Error Accured
                if (result == "{}")
                {
                    new MessageBusPayload(MessageBusPayload.BroadcastEnum.UpdatePostsMode, false)
                        {
                            Entity = mode
                        }
                        .Post();
                }

                var array = AnalyzeArrayResult(result);

                bool hasNewPost = false;
                foreach (var item in array)
                {
                    int id = item.Value<int>("id");
                    var postItem=  Database.GetInstance().GetDbCon().Table<Post>().FirstOrDefault(q => q.Id == id);
                    if (postItem == null)
                    {
                        hasNewPost = true;
                        postItem = new Post()
                        {
                            Id = item.Value<int>("id"),
                            PublishDate = item.Value<int>("publishDate"),
                            Avatar = item.Value<string>("avatar"),
                            BookCoverUrl = item.Value<string>("bookCoverUrl"),
                            BookId = item.Value<int>("bookId"),
                            BookTitle = item.Value<string>("bookTitle"),
                            CommentsCount = item.Value<int>("commentsCount"),
                            Description = item.Value<string>("description"),
                            LikesCount = item.Value<int>("likesCount"),
                            Nickname = item.Value<string>("nickname"),
                            Score = item.Value<byte>("score"),
                            Status = item.Value<int>("status"),
                            UserId = item.Value<int>("userId"),
                            Username = item.Value<string>("username"),
                        };
                        Database.GetInstance().GetDbCon().Insert(postItem);
                    }
                    else
                    {
                        postItem.PublishDate = item.Value<int>("publishDate");
                        postItem.Avatar = item.Value<string>("avatar");
                        postItem.BookCoverUrl = item.Value<string>("bookCoverUrl");
                        postItem.BookId = item.Value<int>("BookId");
                        postItem.BookTitle = item.Value<string>("bookTitle");
                        postItem.CommentsCount = item.Value<int>("commentsCount");
                        postItem.Description = item.Value<string>("description");
                        postItem.LikesCount = item.Value<int>("likesCount");
                        postItem.Nickname = item.Value<string>("nickname");
                        postItem.Score = item.Value<byte>("score");
                        postItem.Status = item.Value<int>("status");
                        postItem.UserId = item.Value<int>("userId");
                        postItem.Username = item.Value<string>("username");
                        Database.GetInstance().GetDbCon().Update(postItem);
                    }
                    string strMode = mode.ToString().ToLower();
                    if (!Database.GetInstance().GetDbCon().Table<PostMode>()
                        .Any(q => q.Mode == strMode && q.PostId == postItem.Id))
                    {
                        Database.GetInstance().GetDbCon().Insert(new PostMode()
                        {
                             Mode = strMode,
                             PostId = postItem.Id
                        });
                    }
                   
                }
                new MessageBusPayload(MessageBusPayload.BroadcastEnum.UpdatePostsMode, hasNewPost)
                    {
                        Entity = mode
                    }
                    .Post();
            });
        }

        public void UpdateAllPosts()
        {
            UpdatePostsOfMode(DataMode.Following);
//            UpdatePostsOfMode(DataMode.Top);
//            UpdatePostsOfMode(DataMode.Latest);
        }


        public enum DataMode
        {
            Latest,
            Following,
            Top
        }
    }
}