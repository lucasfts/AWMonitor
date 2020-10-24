﻿using AWMonitor.Models;
using AWMonitor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AWMonitor.ViewModels
{
    public class NewRoutineVM : BaseViewModel
    {
        private IActuatorService _actuatorService => Xamarin.Forms.DependencyService.Get<IActuatorService>();

        private Sensor sensor;
        private Actuator actuator;
        private string action;
        private AWMonitor.Models.Condition condition;
        private int conditionValue;
        private bool enabled;
        private bool notify;

        public Sensor Sensor { get => sensor; set => SetProperty(ref sensor, value); }
        public Actuator Actuator { get => actuator; set => SetProperty(ref actuator, value); }
        public string Action { get => action; set => SetProperty(ref action, value); }
        public AWMonitor.Models.Condition Condition { get => condition; set => SetProperty(ref condition, value); }
        public int ConditionValue { get => conditionValue; set => SetProperty(ref conditionValue, value); }
        public bool Enabled { get => enabled; set => enabled = SetProperty(ref enabled, value); }
        public bool Notify { get => notify; set => notify = SetProperty(ref notify, value); }

        public ObservableCollection<Actuator> Actuators { get; set; }

        public List<Sensor> Sensors { get; set; } = new List<Sensor>()
        {
            new Sensor { Name = "Nível [IN001]", TankId= 1, Type ="nivel" },
            new Sensor { Name = "Consumo [IN002]", TankId= 1, Type ="consumo" },
            new Sensor { Name = "Temperatura [IN003]", TankId= 1, Type ="temperatura" },
            new Sensor { Name = "PH [IN004]", TankId= 1, Type ="ph" },
            new Sensor { Name = "Nível [OUT001]", TankId= 2, Type ="nivel" },
            new Sensor { Name = "Consumo [OUT002]", TankId= 2, Type ="consumo" },
            new Sensor { Name = "Temperatura [OUT003]", TankId= 2, Type ="temperatura" },
            new Sensor { Name = "PH [OUT004]", TankId= 2, Type ="temperatura" }
        };

        public IEnumerable<string> Actions { get; set; } = new List<string>()
        {
            "On",
            "Off",
        };

        public IEnumerable<AWMonitor.Models.Condition> Conditions { get; set; } = new List<AWMonitor.Models.Condition>()
        {
            new  AWMonitor.Models.Condition { Name = "igual a", Symbol = "==" },
            new  AWMonitor.Models.Condition { Name = "maior que", Symbol = ">" },
            new  AWMonitor.Models.Condition { Name = "maior ou igual a", Symbol = ">=" },
            new  AWMonitor.Models.Condition { Name = "menor que", Symbol = "<" },
            new  AWMonitor.Models.Condition { Name = "menor ou igual a", Symbol = "<=" }
        };

        public NewRoutineVM()
        {
            Title = "Nova Rotina";

            Actuators = new ObservableCollection<Actuator>();
        }

        public async Task LoadActuators()
        {
            IsBusy = true;

            try
            {
                Actuators.Clear();
                var items = await _actuatorService.GetAllAsync();
                foreach (var item in items)
                {
                    Actuators.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
