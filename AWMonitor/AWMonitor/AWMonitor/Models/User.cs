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
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
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

        public event PropertyChangedEventHandler PropertyChanged;

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
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var jsonSerializerSettings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver() };
                    var jsonUser = JsonConvert.SerializeObject(user, jsonSerializerSettings);
                    var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://ec2-18-207-3-216.compute-1.amazonaws.com:1880/users/login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var strResult = response.Content.ReadAsStringAsync().Result;
                        var userLogin = JsonConvert.DeserializeObject<User>(strResult);
                        return true;
                    }

                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
