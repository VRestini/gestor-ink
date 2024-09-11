using AppGestorInk.MVVM.Models;

using AppGestorInk.MVVM.ViewModels;

using CommunityToolkit.Maui.Views;

namespace AppGestorInk.MVVM.Popups;

public partial class EditarProduto : ContentPage

{
	public EditarProduto(EditarProdutoViewModel editarProdutoViewModel)
	{
		InitializeComponent();
        BindingContext = editarProdutoViewModel;
	}
    private async void EditorWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {

        BorderDescription.Stroke = Colors.LightGray;
        
    }

    private async void EditorWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        BorderDescription.Stroke = Color.FromArgb("#4C007D");
        
    }

    private async void EntryWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {
        BorderName.Stroke = Colors.LightGray;
        

    }

    private async void EntryWithoutBorder_Focused(object sender, FocusEventArgs e)
    {

        BorderName.Stroke = Color.FromArgb("#4C007D");
        
    }
}