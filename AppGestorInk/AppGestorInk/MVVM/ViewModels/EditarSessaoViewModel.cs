using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppGestorInk.MVVM.ViewModels
{
    [QueryProperty(nameof(Sessao), "SessaoObject")]
    public partial class EditarSessaoViewModel : ObservableObject
    {
        private readonly ISessaoService _sessaoService;
        private readonly AgendaViewModel _agendaViewModel;

        [ObservableProperty]
        private Sessao _sessao;
        [ObservableProperty]
        public DateTime _dataAtual;
        public EditarSessaoViewModel(ISessaoService sessaoService, AgendaViewModel agendaViewModel)
        {
            _sessaoService = sessaoService;
            _agendaViewModel = agendaViewModel;
            DataAtual = DateTime.Now;
        }

        [RelayCommand]
        private async Task UpdateSessao()
        {
            if (!string.IsNullOrEmpty(Sessao.NomeSessao))
            {
                try
                {
                    await _sessaoService.InitializeAsync();
                    await _sessaoService.UpdateSessaoAsync(Sessao);  // Atualiza a sessão no banco de dados

                    await Shell.Current.GoToAsync(".."); // Volta para a página anterior após a edição
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", "Nome da Sessão não pode ser vazio", "OK");
            }
        }

        [RelayCommand]
        private async Task DeleteSessao()
        {
            bool option = await Shell.Current.DisplayAlert("Deletar Sessão", "Tem certeza que deseja deletar esta sessão?", "Sim", "Não");
            if (option)
            {
                try
                {
                    await _sessaoService.InitializeAsync();
                    await _sessaoService.DeleteSessaoAsync(Sessao);  // Deleta a sessão no banco de dados

                    await Shell.Current.DisplayAlert("Sucesso", "Sessão excluída", "OK");
                    await Shell.Current.GoToAsync(".."); // Volta para a página anterior após a exclusão
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
                }
            }
        }
    }
}
