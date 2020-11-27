using AWMonitor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AWMonitor.Services.Helpers
{
    public static class HttpHelper
    {
        private static ISettingsService _settingsService => DependencyService.Get<ISettingsService>();

        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static async Task<HttpResponseMessage> GetAsync(string methodUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = Path.Combine(await GetApiUrl(), methodUrl);
                return await client.GetAsync(url);
            }
        }

        public static async Task<HttpResponseMessage> PostAsync<T>(string methodUrl, T data) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(data, _jsonSerializerSettings);
                var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var url = Path.Combine(await GetApiUrl(), methodUrl);
                var response = await client.PostAsync(url, contentData);
                return response;
            }
        }

        public static async Task<HttpResponseMessage> DeleteAsync(string methodUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = Path.Combine(await GetApiUrl(), methodUrl);
                var response = await client.DeleteAsync(url);
                return response;
            }
        }

        private static async Task<string> GetApiUrl()
        {
            var settings = await _settingsService.GetFirstOrDefaultAsync();
            var _apiUrl = settings != null ? $"{settings.Url}:{settings.Port}" : "http://ec2-54-146-195-150.compute-1.amazonaws.com:1880";

            return _apiUrl;
        }
    }
}
