using AppGestorInk.MVVM.Views;
using CommunityToolkit.Maui.Views;
using AppGestorInk.Services;
using AppGestorInk.MVVM.ViewModels;
using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.Popups;
using AppGestorInk;


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

    private async void Button_Clicked(object sender, EventArgs e)
    {
       
        var a = new MenuPopup();
        
        await this.ShowPopupAsync(a);
    }
}