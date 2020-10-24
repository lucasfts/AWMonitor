using AWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public interface  IActuatorService
    {
        Task<IEnumerable<Actuator>> GetAllAsync();
    }
}
