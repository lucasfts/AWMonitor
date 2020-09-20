using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public class WebClientService
    {
        private readonly static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static async Task<HttpResponseMessage> PostAsync<T>(string url, T data) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(data, _jsonSerializerSettings);
                var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");
                return await client.PostAsync(url, contentData);
            }
        }
    }
}
