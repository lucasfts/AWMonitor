using AWMonitor.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AWMonitor.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly SQLiteAsyncConnection _database;

        public SettingsService()
        {
            var connectionString = Path.Combine(FileSystem.AppDataDirectory, "awmonitor.db");
            _database = new SQLiteAsyncConnection(connectionString);
            _database.CreateTableAsync<Settings>().Wait();
        }

        public async Task<bool> AddItemAsync(Settings item)
        {
            await _database.InsertAsync(item);
            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var item = await _database.Table<Settings>().FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            await _database.DeleteAsync(item);
            return true;
        }

        public async Task<Settings> GetFirstOrDefaultAsync()
        {
            var item = await _database.Table<Settings>().FirstOrDefaultAsync();
            return item;
        }

        public async Task<Settings> GetItemAsync(string id)
        {
            var item = await _database.Table<Settings>().FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            return item;
        }

        public async Task<IEnumerable<Settings>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _database.Table<Settings>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Settings item)
        {
            await _database.UpdateAsync(item);
            return true;
        }
    }
}
