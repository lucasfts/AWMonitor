using AWMonitor.Models;
using AWMonitor.Services.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public class ActuatorService : IActuatorService
    {
        public async Task<IEnumerable<Actuator>> GetAllAsync()
        {
            var response = await HttpHelper.GetAsync($"actuators");

            if (response.IsSuccessStatusCode)
            {
                var strResult = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<Actuator>>(strResult);
            }

            return null;
        }
    }
}
