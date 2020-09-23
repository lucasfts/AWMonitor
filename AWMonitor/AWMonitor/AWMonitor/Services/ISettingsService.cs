using AWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public interface ISettingsService : IDataStore<Settings>
    {
        Task<Settings> GetFirstOrDefaultAsync();
    }
}
