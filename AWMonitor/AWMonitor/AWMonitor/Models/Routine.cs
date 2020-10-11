﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.Models
{
    public class Routine
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public Sensor Sensor { get; set; }
        public Actuator Actuator { get; set; }
        public string Action { get; set; }
        public Condition Condition { get; set; }
        public int ConditionValue { get; set; }
        public bool Enabled { get; set; }
        public bool Notify { get; set; }

        public string DisplayName => $"{Sensor?.Name} {Condition?.Name} {ConditionValue} ({Action} {Actuator?.Name})";

    }
}
