using AWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWMonitor.Services
{
    public interface IUserService
    {
        Task<bool> Login(User user);
        Task<bool> Register(User user);
    }
}
