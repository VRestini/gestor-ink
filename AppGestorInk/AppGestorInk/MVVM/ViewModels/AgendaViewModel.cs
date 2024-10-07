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
            selectedDate = new DateTime();
        }
        [RelayCommand]
        public async Task Initialize()
        {
            await _sessaoService.InitializeAsync();
        }
        [RelayCommand]
        public async Task GetSessaoByDate()
        {
            sessaoList.Clear();  // Limpa a lista de todas as sessões
            sessaoListByDate.Clear();  // Limpa a lista de sessões filtradas por data

            try
            {
                // Exibe a data selecionada
                await Shell.Current.DisplayAlert("Data Selecionada", $"A nova data selecionada é: {SelectedDate:dd/MM/yyyy}", "OK");

                // Obtém todas as sessões do banco de dados
                var sessoes = await _sessaoService.GetAllSessoesAsync();

                // Adiciona todas as sessões à lista geral
                foreach (var sessao in sessoes)
                {
                    sessaoList.Add(sessao);
                }

                // Filtra as sessões pela data selecionada
                var sessoesFiltradas = sessoes.Where(x => x.Data.Date == SelectedDate.Date).ToList();

                // Adiciona as sessões filtradas à lista
                foreach (var sessao in sessoesFiltradas)
                {
                    sessaoListByDate.Add(sessao);
                }

                // Verifica se há sessões filtradas
                if (sessoesFiltradas.Count == 0)
                {
                    await Shell.Current.DisplayAlert("Aviso", "Nenhuma sessão encontrada para a data selecionada.", "OK");
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
            Sessao novaSessao = new Sessao
            {
                Id = 1,
                Nome = "Sessão Teste",
                Descricao = "Descrição da Sessão Teste",
                Data = DateTime.Now // Ajuste a data conforme necessário
            };

            await _sessaoService.AddSessaoAsync(novaSessao);

            // Exibe uma mensagem de confirmação
            await Shell.Current.DisplayAlert("Sessão Adicionada", $"A sessão '{novaSessao.Nome}' foi adicionada com sucesso!", "OK");

            // Atualiza a lista de sessões
            await GetSessaoByDate();
        }


    }
}
