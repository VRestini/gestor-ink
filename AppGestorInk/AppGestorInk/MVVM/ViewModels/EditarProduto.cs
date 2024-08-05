using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AppGestorInk.MVVM.ViewModels
{
    [QueryProperty(nameof(Produto), "ProdutoObject")]
    public partial class EditarProduto : ObservableObject
    {
        private readonly IProdutoService _produtoService;
        [ObservableProperty]
        private Produto _produto;

        public EditarProduto(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
    }
}
