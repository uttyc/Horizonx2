using Horizonx2.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horizonx2
{
    public partial class App : Application
    {
        //public EksiDb database;

        //public static EksiDb Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new EksiDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Favs.db3"));
        //        }
        //        return database;
        //    }
        //}
        public static string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Favs.db3");
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage1();
            //Mas = new MasterDetailPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
