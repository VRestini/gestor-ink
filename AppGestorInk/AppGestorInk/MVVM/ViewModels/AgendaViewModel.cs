using CommunityToolkit.Mvvm.ComponentModel;
using AppGestorInk.MVVM.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using AppGestorInk.Services;

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
    
        }
        [RelayCommand]
        public async Task GetAllSessao()
        {
            sessaoList.Clear();
            try
            {
                await _sessaoService.InitializeAsync();
                DateTime data = SelectedDate;
                sessaoList.Add(new Sessao { Id = 1, Nome = "Sessão 1", Descricao = "Descrição da Sessão 1", Data = DateTime.Now });
                sessaoList.Add(new Sessao { Id = 2, Nome = "Sessão 2", Descricao = "Descrição da Sessão 2", Data = DateTime.Now.AddDays(1) });
                sessaoList.Add(new Sessao { Id = 3, Nome = "Sessão 3", Descricao = "Descrição da Sessão 3", Data = DateTime.Now.AddDays(2) });
                sessaoList.Add(new Sessao { Id = 4, Nome = "Sessão 4", Descricao = "Descrição da Sessão 4", Data = DateTime.Now.AddDays(3) });
                var sessoes = await _sessaoService.GetSessaoByDateAsync(SelectedDate);         
                foreach (var sessao in sessoes)
                {
                     sessaoList.Add(sessao);
                }              
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        public async Task GetSessaoByDate()
        {         
            try
            {
                var sessoess = await _sessaoService.GetSessaoByDateAsync(SelectedDate);
                foreach (var sessao in sessoess)
                {
                    sessaoListByDate.Add(sessao);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            
        }
    }
}
