using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.ViewModels;
namespace AppGestorInk.MVVM.Popups;

public partial class EditarProduto : ContentPage
{
	public EditarProduto(EditarProdutoViewModel editarProdutoViewModel)
	{
		InitializeComponent();
        BindingContext = editarProdutoViewModel;
	}
    
}