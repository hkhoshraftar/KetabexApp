using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ketabex.Shared.Models
{
    public class PostMode
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Mode { get; set; }

    }
}
