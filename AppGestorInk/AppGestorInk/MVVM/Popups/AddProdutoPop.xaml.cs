
using AppGestorInk.MVVM.ViewModels;
using AppGestorInk.MVVM.Views;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
namespace AppGestorInk.MVVM.Popups;

public partial class AddProdutoPop : ContentPage
{
    // Só funciona como contentpage, popup nn
    
    public AddProdutoPop(AddProdutoViewModel addProdutoViewModel)
	{
		InitializeComponent();
        BindingContext = addProdutoViewModel;
	}

    private async void EditorWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {
        
        BorderDescription.Stroke = Colors.LightGray;
        await BorderDescription.ScaleTo(1, 100, Easing.CubicOut);
    }
    
    private async void EditorWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        BorderDescription.Stroke = Color.FromArgb("#4C007D");
        await BorderDescription.ScaleTo(1.05, 100, Easing.CubicIn);
    }

    private async void EntryWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {
        BorderName.Stroke = Colors.LightGray;
        await BorderName.ScaleTo(1, 100, Easing.CubicOut);
    }

    private async void EntryWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        
        BorderName.Stroke = Color.FromArgb("#4C007D");
        await BorderName.ScaleTo(1.05, 100, Easing.CubicIn);
    }
}