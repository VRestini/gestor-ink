
using AppGestorInk.MVVM.ViewModels;
using AppGestorInk.MVVM.Views;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
namespace AppGestorInk.MVVM.Popups;

public partial class AddProdutoPop : ContentPage
{
    // S� funciona como contentpage, popup nn
    
    public AddProdutoPop(AddProdutoViewModel addProdutoViewModel)
	{
		InitializeComponent();
        BindingContext = addProdutoViewModel;
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