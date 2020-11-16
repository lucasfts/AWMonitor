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
        Task<ValidationResult> Register(User user);
        Task<int> GetChangePasswordCode(string phone);
        Task<ValidationResult> ChangePassword(string phone, int changePasswordCode, string password);
        Task<User> GetLastUserLoginAsync();
    }
}
