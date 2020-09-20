using AWMonitor.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string id;

        [JsonProperty("_id")]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("_Id");
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                if (value == null || value.Length <= 11)
                {
                    phone = value;
                }

                OnPropertyChanged("Phone");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (value == null || value.Length <= 4)
                {
                    password = value;
                }

                OnPropertyChanged("Password");
            }
        }

        public static async Task<bool> Login(User user)
        {
            var response = await WebClientService.PostAsync("http://ec2-18-207-3-216.compute-1.amazonaws.com:1880/users/login", user);

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                var userLogin = JsonConvert.DeserializeObject<User>(strResult);
                return true;
            }

            return false;
        }

        public static async Task<bool> Register(User user)
        {
            var response = await WebClientService.PostAsync("http://ec2-18-207-3-216.compute-1.amazonaws.com:1880/users/save", user);

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                var userLogin = JsonConvert.DeserializeObject<User>(strResult);
                return true;
            }

            return false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
