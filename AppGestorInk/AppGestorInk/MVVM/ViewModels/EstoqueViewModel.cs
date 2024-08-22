using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.Popups;
using AppGestorInk.MVVM.Views;
using AppGestorInk.Services;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace AppGestorInk.MVVM.ViewModels
{
    public partial class EstoqueViewModel : ObservableObject
    {
        public readonly IProdutoService _produtoService;
        public ObservableCollection<Produto> ProdutoList { get; set; } = new();// ObservableCollection pq as alterações feitas nos dados do produto sejam notificadas na interface

        public EstoqueViewModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;            
        }
        [RelayCommand] // serve para gerar um comando com o nome do método + command
        public async Task GetProduto()
        {
            ProdutoList.Clear();
            try
            {
                await _produtoService.InitializeAsync(); // sempre tem que iniciar o serviço sqlite
                var produtos = await _produtoService.GetProdutoAsync();
                if (produtos.Any())
                {
                    foreach (var produto in produtos)
                    {
                        ProdutoList.Add(produto);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async Task teste()
        {
            var uri = $"{nameof(EstoqueRelatorio)}?id=3";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async Task AddProduto()
        {
            var uri = $"{nameof(AddProdutoPop)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async Task RefreshProduto(Produto produto)
        {
            var uri = $"{nameof(EditarProduto)}?id=1";

            await Shell.Current.GoToAsync(uri, new Dictionary<string, object>
            {
                { "ProdutoObject", produto }
            });
        }
        [RelayCommand]
        private async Task DeleteProduto(Produto produto)
        {
            bool option = await Shell.Current.DisplayAlert("Deletar", "a", "Sim", "Não");
            if (option is true)
            {
                try
                {
                    await _produtoService.InitializeAsync();
                    await _produtoService.DeleteProdutoAsync(produto);
                    await Shell.Current.DisplayAlert("Sucesso", "Produto excluido", "ok");
                    await GetProduto();
                }
                catch
                (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
                }
            }
        }

    }
}
