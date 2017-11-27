using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ketabex.Shared.Models
{
    public class Comment
    {
        [PrimaryKey]

        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> ReplyTo { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }



    }
}
