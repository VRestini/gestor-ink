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
        [ObservableProperty]
        private Produto _produto;

        public EditarProdutoViewModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;
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
                await Shell.Current.DisplayAlert("Error", "Livro sem Título", "OK");
            }
        }
    }
}
