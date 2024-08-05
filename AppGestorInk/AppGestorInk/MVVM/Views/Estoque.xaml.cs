using AppGestorInk.MVVM.Views;


using AppGestorInk.Services;
using AppGestorInk.MVVM.ViewModels;

using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.Popups;
using AppGestorInk;
using CommunityToolkit.Maui.Views;

namespace AppGestorInk.MVVM.Views;

public partial class Estoque : ContentPage
{
    private readonly IProdutoService _produtoService;
    public Estoque(EstoqueViewModel estoqueViewModel, IProdutoService produtoService)
    {
        InitializeComponent();

        BindingContext = estoqueViewModel;
        _produtoService = produtoService;
        
    }

}