using AWMonitor.Models;
using AWMonitor.Services.Helpers;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _database => SQLiteHelper.GetAsyncConnection();

        public UserService()
        {
            _database.CreateTableAsync<User>().Wait();
        }

        public async Task<bool> Login(User user)
        {
            var response = await HttpHelper.PostAsync("users/login", user);

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                var lastUser = await GetLastUserLoginAsync();
                if (lastUser == null)
                {
                    await _database.InsertAsync(user);
                }
                else
                {
                    if (lastUser.Id != user.Id || lastUser.Phone != user.Phone || lastUser.Password != user.Password)
                    {
                        await _database.Table<User>().DeleteAsync(x => true);
                        await _database.InsertAsync(user);
                    }
                }
                return true;
            }

            return false;
        }

        public async Task<ValidationResult> Register(User user)
        {
            var response = await HttpHelper.PostAsync("users/register", user);
            var strResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return new ValidationResult { Result = true};
            }

            return new ValidationResult { Result = false, ErrorMessage = strResult };
        }

        public async Task<int> GetChangePasswordCode(string phone)
        {
            var response = await HttpHelper.PostAsync("users/forget-password/code", new { Phone = phone });

            var strResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return int.Parse(strResult);
            }

            throw new Exception(strResult);
        }

        public async Task<ValidationResult> ChangePassword(string phone, int changePasswordCode, string password)
        {
            var data = new { Phone = phone, ChangePasswordCode = changePasswordCode, Password = password };
            var response = await HttpHelper.PostAsync("users/change-password", data);
            var strResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return new ValidationResult { Result = true };
            }

            return new ValidationResult { Result = false, ErrorMessage = strResult };
        }

        public async Task<User> GetLastUserLoginAsync()
        {
            var item = await _database.Table<User>().FirstOrDefaultAsync();
            return item;
        }
    }
}
