using CommunityToolkit.Mvvm.ComponentModel;
using GestorInk.Repositorys;
using GestorInk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.ViewModel.ViewModelScheduler
{
    public partial class SchedulerFeedVM: ObservableObject
    {
        public ISessionService _sessionservice;

        public SchedulerFeedVM(ISessionService sessionservice)
        {
            _sessionservice = sessionservice;
            Init();
        }
        public async Task Init()
        {
            _sessionservice.Init();
        }
    }
}
