using System;
using CarTravel.Data;
using System.IO;

namespace CarTravel
{
    public partial class App : Application
    {
        static CarListDatabase database;
        public static CarListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CarListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CarList.db3"));
                }
            return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
