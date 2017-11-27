using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ketabex.Shared.Models
{
    public class Post
    {
        [PrimaryKey]

        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public byte Score { get; set; }
        public int PublishDate { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string BookTitle { get; set; }
        public string Avatar { get; set; }
        public string BookCoverUrl { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }


    }
}
