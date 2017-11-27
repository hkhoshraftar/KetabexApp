using System;
using System.Threading.Tasks;
using Ketabex.Shared.Models;
using SQLite;

namespace Ketabex.lib
{
    public class Database
    {
        private static Database instance = null;
        public static Database GetInstance()
        {
            return instance ?? (instance = new Database(GlobalUtil.NativeUtil.GetDbPath()));
        }

        public Database(string path)
        {

            CreateDatabase(path);
        }


        private SQLiteConnection connection;
        public SQLiteConnection GetDbCon()
        {
            return connection;
        }
        public async Task<bool> CreateDatabase(string path)
        {
            try
            {
                connection = new SQLiteConnection(path);
                connection.CreateTable<User>();
                connection.CreateTable<Book>();
                connection.CreateTable<Comment>();
                connection.CreateTable<Post>();
                connection.CreateTable<PostMode>();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
