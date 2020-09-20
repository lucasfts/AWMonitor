using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.Models
{
    public class Routine
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Actuator { get; set; }
        public string Action { get; set; }
        public string Condition { get; set; }
        public int ConditionValue { get; set; }
        public bool Enabled { get; set; }
        public bool Notify { get; set; }

        public string DisplayName => $"{Actuator} {Condition} {ConditionValue} ({Action})";

    }
}
