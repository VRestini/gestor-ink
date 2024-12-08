using AppGestorInk.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.Services
{
    public interface IUserService
    {
        Task Login(User user);
        Task<string> GetProtectedData();
        Task Logout();
        Task <bool> IsUserLoggedIn();
    }
}
