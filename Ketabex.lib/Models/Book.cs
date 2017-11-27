using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ketabex.Shared.Models
{
    public class Book
    {
        [PrimaryKey]
          public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Nullable<short> PagesCount { get; set; }
        public Nullable<int> Price { get; set; }
        public string Description { get; set; }
        public string CoverUrl { get; set; }

    }
}
