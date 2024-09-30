
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
        public event PropertyChangedEventHandler PropertyChanged;
        [RelayCommand]
        public async Task OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [RelayCommand]
        public async Task GetSessaoByDate(DateTime date)
        {
            sessaoList.Clear();
            try
            {
                await _sessaoService.InitializeAsync();
                var produtos = await _sessaoService.GetSessaoByDateAsync(date);
                if (produtos.Any())
                {
                    foreach (var produto in produtos)
                    {
                        sessaoList.Add(produto);
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
