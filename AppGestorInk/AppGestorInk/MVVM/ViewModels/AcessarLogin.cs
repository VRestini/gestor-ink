using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AcessarLogin
    {
        public readonly UserService _userService;

        [RelayCommand]
        private async Task Login(User user)
        {
            
            await _userService.Login(user);
        }
    }
}
