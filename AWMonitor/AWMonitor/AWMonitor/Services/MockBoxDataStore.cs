using AWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public class MockBoxDataStore : IDataStore<QualityBox>
    {
        readonly List<QualityBox> boxes;

        public MockBoxDataStore()
        {
            boxes = new List<QualityBox>() { 
              new QualityBox { Name = "QB001 - Entrada"},
              new QualityBox { Name = "QB001 - Saída"}
            };
        }

        public async Task<bool> AddItemAsync(QualityBox box)
        {
            boxes.Add(box);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(QualityBox box)
        {
            var oldBox = boxes.Where((QualityBox arg) => arg.Id == box.Id).FirstOrDefault();
            boxes.Remove(oldBox);
            boxes.Add(box);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldBox = boxes.Where((QualityBox arg) => arg.Id == id).FirstOrDefault();
            boxes.Remove(oldBox);

            return await Task.FromResult(true);
        }

        public async Task<QualityBox> GetItemAsync(string id)
        {
            return await Task.FromResult(boxes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<QualityBox>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(boxes);
        }
    }
}
