
using AppGestorInk.MVVM.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppGestorInk.Services;
using Syncfusion.Maui.Calendar;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AgendaViewModel
    {
        public readonly SessaoService _sessaoService;
        public ObservableCollection<Sessao> sessaoList { get; set; } = new();

        public AgendaViewModel(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }
        
        
        [RelayCommand]
        public async Task GetAllSessao()
        {
            sessaoList.Clear();
            try
            {
                await _sessaoService.InitializeAsync();
                var sessoes = await _sessaoService.GetAllSessoesAsync();
                if (sessoes.Any())
                {
                    foreach (var sessao in sessoes)
                    {
                        sessaoList.Add(sessao);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
