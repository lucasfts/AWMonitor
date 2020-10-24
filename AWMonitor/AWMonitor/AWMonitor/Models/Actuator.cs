using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.Models
{
    public class Actuator
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
    }
}
