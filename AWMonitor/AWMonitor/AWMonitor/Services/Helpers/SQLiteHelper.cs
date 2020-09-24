using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace AWMonitor.Services.Helpers
{
    public static class SQLiteHelper
    {
        private static SQLiteAsyncConnection _database;

        public static SQLiteAsyncConnection GetAsyncConnection()
        {
            if (_database == null)
            {
                var connectionString = Path.Combine(FileSystem.AppDataDirectory, "awmonitor.db");
                _database = new SQLiteAsyncConnection(connectionString);
            }

            return _database;
        }
    }
}
