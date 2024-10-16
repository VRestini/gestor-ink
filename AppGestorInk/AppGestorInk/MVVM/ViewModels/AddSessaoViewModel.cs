using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AddSessaoViewModel: ObservableObject
    {
        public readonly ISessaoService _sessaoService;
        [ObservableProperty]
        public string _sessaoName;
        [ObservableProperty]
        public string _sessaoDescricao;
        [ObservableProperty]
        public DateTime _sessaoDate;
        public AddSessaoViewModel(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }
        [RelayCommand]
        private async Task AddSessao()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessaoName)) // verifica se o nome foi informado
                {
                    Sessao sessao = new()
                    {
                        Nome = SessaoName,
                        Descricao = SessaoDescricao,
                        Data = SessaoDate
                    };
                    await _sessaoService.InitializeAsync();
                    await _sessaoService.AddSessaoAsync(sessao);

                    await Shell.Current.GoToAsync(".."); // voltar para a página anterior
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Livro sem Título", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


        }
    }
}
