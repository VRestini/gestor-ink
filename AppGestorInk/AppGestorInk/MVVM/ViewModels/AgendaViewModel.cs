using CommunityToolkit.Mvvm.ComponentModel;
using AppGestorInk.MVVM.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using AppGestorInk.Services;
using AppGestorInk.MVVM.Popups;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AgendaViewModel : ObservableObject
    {

        [ObservableProperty]
        public DateTime selectedDate;

        public readonly ISessaoService _sessaoService;
        public ObservableCollection<Sessao> sessaoList { get; set; } = new();
        public ObservableCollection<Sessao> sessaoListByDate { get; set; } = new();

        public AgendaViewModel(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
            selectedDate = new DateTime();
        }
        [RelayCommand]
        public async Task Initialize()
        {
            await _sessaoService.InitializeAsync();
            await GetSessaoByDate();
        }
        [RelayCommand]
        public async Task GetSessaoByDate()
        {
            sessaoList.Clear();
            sessaoListByDate.Clear(); 

            try
            {
                var sessoes = await _sessaoService.GetAllSessoesAsync();
                foreach (var sessao in sessoes)
                {
                    sessaoList.Add(sessao);
                }
                var sessoesFiltradas = sessoes.Where(x => x.Data.Date == SelectedDate.Date).ToList().OrderBy(x => x.Data);
                foreach (var sessao in sessoesFiltradas)
                {
                    sessaoListByDate.Add(sessao);
                }
 
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task AddSessao()
        {
            var uri = $"{nameof(AddSessaoView)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        public async Task RefreshSessao(Sessao sessao)
        {
            var uri = $"{nameof(EditarSessaoView)}?id=1322";
            await Shell.Current.GoToAsync(uri, new Dictionary<string, object>
            {
                { "SessaoObject", sessao }
            });
        }
    }
}
