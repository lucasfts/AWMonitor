﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.ViewModels
{
    public class NewRoutineVM : BaseViewModel
    {
        private string actuator;
        private string action;
        private string condition;
        private int conditionValue;
        private bool enabled;
        private bool notify;

        public string Actuator { get => actuator; set => SetProperty(ref actuator, value); }
        public string Action { get => action; set => SetProperty(ref action, value); }
        public string Condition { get => condition; set => SetProperty(ref condition, value); }
        public int ConditionValue { get => conditionValue; set => SetProperty(ref conditionValue, value); }
        public bool Enabled { get => enabled; set => enabled = SetProperty(ref enabled, value); }
        public bool Notify { get => notify; set => notify = SetProperty(ref notify, value); }

        public List<string> Actuators { get; set; } = new List<string>()
        {
            "Bomba [IN001]",
            "Solenóide [IN002]",
            "Bomba [OUT001]",
            "Solenóide [OUT002]",
        };

        public List<string> Actions { get; set; } = new List<string>()
        {
            "Ligar",
            "Desligar",
        };

        public List<string> Conditions { get; set; } = new List<string>()
        {
            "igual a",
            "maior que",
            "maior ou igual a",
            "menor que",
            "menor ou igual a",
        };
    }
}