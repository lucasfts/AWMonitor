using AWMonitor.Models;
using AWMonitor.Services.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public class RoutineService : IRoutineService
    {
        public RoutineService()
        {
            
        }

        public async Task<bool> AddItemAsync(Routine item)
        {
            var response = await HttpHelper.PostAsync("routines/insert", item);

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                var routineId = JsonConvert.DeserializeObject<Routine>(strResult).Id;
                item.Id = routineId;

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var response = await HttpHelper.DeleteAsync($"routines/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Routine> GetItemAsync(string id)
        {
            var response = await HttpHelper.GetAsync($"routines/{id}");

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Routine>(strResult);
            }

            return null;
        }

        public async Task<IEnumerable<Routine>> GetItemsAsync(bool forceRefresh)
        {
            var response = await HttpHelper.GetAsync($"routines");

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<Routine>>(strResult);
            }

            return null;
        }

        public async Task<bool> UpdateItemAsync(Routine item)
        {
            var response = await HttpHelper.PostAsync("routines/update", item);

            return response.IsSuccessStatusCode;
        }
    }
}
