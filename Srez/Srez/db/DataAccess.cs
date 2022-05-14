using System;
using System.Collections.Generic;
using System.Linq;
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
            db.CreateTable<Project>();
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
        public int SaveProject(Project project)
        {
            if (project.Id != 0)
            {
                db.Update(project);
                return project.Id;
            }
            else
                return db.Insert(project);
        }

        public int DeleteProject(int idProject)
        {
            return db.Delete<Project>(idProject);
        }
        public int UpdateUser(User user)
        {
            return db.Update(user);
        }

        public IEnumerable<Project> GetProjects()
        {
            return db.Table<Project>().ToList();
        }

        public IEnumerable<Project> GetProjectsByUser(int idUser)
        {
            return GetProjects().Where(project => project.User_Id == idUser);
        }
    }
}
