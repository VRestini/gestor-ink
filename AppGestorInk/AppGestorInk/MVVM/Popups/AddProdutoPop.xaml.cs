
using AppGestorInk.MVVM.ViewModels;
using AppGestorInk.MVVM.Views;
using CommunityToolkit.Maui.Views;
namespace AppGestorInk.MVVM.Popups;

public partial class AddProdutoPop : ContentPage
{
    // Só funciona como contentpage, popup nn
    public AddProdutoPop(AddProdutoViewModel addProdutoViewModel)
	{
		InitializeComponent();
        BindingContext = addProdutoViewModel;
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {
      
    }
}