using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Srez.Pages;
using System.IO;
using Srez.db;

namespace Srez
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Clicker.db";
        public static DataAccess db;
        public static int userID;

        public static DataAccess Db
        {
            get
            {
                if (db == null)
                {
                    db = new DataAccess(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage =  new NavigationPage(new Pages.AuthPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
