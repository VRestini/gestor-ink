using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppGestorInk.MVVM.ViewModels
{
    [QueryProperty(nameof(Produto), "ProdutoObject")]
    public partial class EditarProdutoViewModel : ObservableObject
    {
        private readonly IProdutoService _produtoService;
        private readonly EstoqueViewModel _estoqueViewModel;
        [ObservableProperty]
        private Produto _produto;

        public EditarProdutoViewModel(IProdutoService produtoService, EstoqueViewModel estoqueViewModel)
        {
            _produtoService = produtoService;
            _estoqueViewModel = estoqueViewModel;
        }
        [RelayCommand]
        private async Task DeleteProduto(Produto produto)
        {
            bool option = await Shell.Current.DisplayAlert("Deletar", "a", "Sim", "Não");
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }
            if (option is true)
            {
                try
                {
                    await _produtoService.InitializeAsync();
                    await _produtoService.DeleteProdutoAsync(produto);
                    await Shell.Current.DisplayAlert("Sucesso", "Produto excluido", "ok");
                    await Shell.Current.GoToAsync("..");
                }
                catch
                (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
                }
            }
        }
        [RelayCommand]
        private async Task RefreshProduto()
        {
            if (!string.IsNullOrEmpty(Produto.Name))
            {
                await _produtoService.InitializeAsync();
                await _produtoService.RefreshProdutoAsync(Produto);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Produto sem nome", "OK");
            }
        }
    }
}
