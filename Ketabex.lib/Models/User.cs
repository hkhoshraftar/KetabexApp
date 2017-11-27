using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace Ketabex.Shared.Models
{
    public class User 
    {
        [PrimaryKey]

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public bool Inactive { get; set; }
        public string Bio { get; set; }
        public string Avatar { get; set; }
    }
}
