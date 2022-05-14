using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Srez.db
{
    public class DataAccess
    {
        private SQLiteConnection db;

        public DataAccess(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<User>();
        }

        public User GetUser(int id)
        {
            return db.Get<User>(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Table<User>();
        }

        public int DelUser(int id) 
        { 
            return db.Delete<User>(id); 
        }

        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                db.Update(user);
                return user.Id;
            }
            else
                return db.Insert(user);
        }

        public int UpdateUser(User user)
        {
            return db.Update(user);
        }
    }
}
