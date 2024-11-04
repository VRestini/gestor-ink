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
        public string _sessaoNome;
        [ObservableProperty]
        public string _clienteNome;
        [ObservableProperty]
        public string _sessaoDescricao;
        [ObservableProperty]
        public DateTime _sessaoDate;

        public DateTime Date { get; set; }
        public AddSessaoViewModel(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
            Date = DateTime.Now;
        }
        [RelayCommand]
        private async Task AddSessao()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessaoNome)) // verifica se o nome foi informado
                {
                    Sessao sessao = new()
                    {
                        NomeSessao = SessaoNome,
                        NomeCliente = ClienteNome,
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
        
        public async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }
    }
}
