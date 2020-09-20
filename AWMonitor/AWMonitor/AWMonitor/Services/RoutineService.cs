using AWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public class RoutineService : IDataStore<Routine>
    {
        readonly List<Routine> items;

        public RoutineService()
        {
            items = new List<Routine>()
            {
                new Routine
                {
                    Actuator = "Bomba [IN001]",
                    Condition = "igual a",
                    ConditionValue = 0,
                    Action = "Ligar"
                },
                new Routine
                {
                    Actuator = "Solenóide [OUT002]",
                    Condition = "maior que",
                    ConditionValue = 2,
                    Action = "Desligar"
                }
            };
        }

        public async Task<bool> AddItemAsync(Routine item)
        {
            items.Add(item);

            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);
            items.Remove(item);

            return true;
        }

        public async Task<Routine> GetItemAsync(string id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);

            return item;
        }

        public async Task<IEnumerable<Routine>> GetItemsAsync(bool forceRefresh = false)
        {
            return items;
        }

        public async Task<bool> UpdateItemAsync(Routine item)
        {
            var oldItem = items.FirstOrDefault(x => x.Id == item.Id);
            items.Remove(oldItem);
            items.Add(item);

            return true;
        }
    }
}
