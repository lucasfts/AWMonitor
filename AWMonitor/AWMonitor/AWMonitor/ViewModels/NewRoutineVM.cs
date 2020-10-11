using AWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWMonitor.ViewModels
{
    public class NewRoutineVM : BaseViewModel
    {
        private Sensor sensor;
        private Actuator actuator;
        private string action;
        private Condition condition;
        private int conditionValue;
        private bool enabled;
        private bool notify;

        public Sensor Sensor { get => sensor; set => SetProperty(ref sensor, value); }
        public Actuator Actuator { get => actuator; set => SetProperty(ref actuator, value); }
        public string Action { get => action; set => SetProperty(ref action, value); }
        public Condition Condition { get => condition; set => SetProperty(ref condition, value); }
        public int ConditionValue { get => conditionValue; set => SetProperty(ref conditionValue, value); }
        public bool Enabled { get => enabled; set => enabled = SetProperty(ref enabled, value); }
        public bool Notify { get => notify; set => notify = SetProperty(ref notify, value); }

        public List<Sensor> Sensors { get; set; } = new List<Sensor>()
        {
            new Sensor { Name = "Nível [IN001]", TankId= 1, Type ="nivel" },
            new Sensor { Name = "Vazão [IN002]", TankId= 1, Type ="vazao" },
            new Sensor { Name = "Temperatura [IN003]", TankId= 1, Type ="temperatura" },
            new Sensor { Name = "PH [IN004]", TankId= 1, Type ="ph" },
            new Sensor { Name = "Nível [OUT001]", TankId= 2, Type ="nivel" },
            new Sensor { Name = "Vazão [OUT002]", TankId= 2, Type ="vazao" },
            new Sensor { Name = "Temperatura [OUT003]", TankId= 2, Type ="temperatura" },
            new Sensor { Name = "PH [OUT004]", TankId= 2, Type ="temperatura" }
        };

        public List<Actuator> Actuators { get; set; } = new List<Actuator>()
        {
           new Actuator{ Name ="Bomba [IN001]", Topic="atuadores/IN001" },
           new Actuator{ Name ="Solenóide [IN002]", Topic="atuadores/IN002" },
           new Actuator{ Name ="Bomba [OUT001]", Topic="atuadores/OUT001" },
           new Actuator{ Name ="Solenóide [OUT002]", Topic="atuadores/OUT002" },
        };

        public List<string> Actions { get; set; } = new List<string>()
        {
            "Ligar",
            "Desligar",
        };

        public List<Condition> Conditions { get; set; } = new List<Condition>()
        {
            new Condition { Name = "igual a", Symbol = "==" },
            new Condition { Name = "maior que", Symbol = ">" },
            new Condition { Name = "maior ou igual a", Symbol = ">=" },
            new Condition { Name = "menor que", Symbol = "<" },
            new Condition { Name = "menor ou igual a", Symbol = "<=" }
        };
    }
}
