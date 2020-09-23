using AWMonitor.Models;
using AWMonitor.Services.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public class UserService : IUserService
    {
        public async Task<bool> Login(User user)
        {
            var response = await HttpHelper.PostAsync("users/login", user);

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                var userLogin = JsonConvert.DeserializeObject<User>(strResult);
                return true;
            }

            return false;
        }

        public async Task<bool> Register(User user)
        {
            var response = await HttpHelper.PostAsync("users/save", user);

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                var userLogin = JsonConvert.DeserializeObject<User>(strResult);
                return true;
            }

            return false;
        }
    }
}
