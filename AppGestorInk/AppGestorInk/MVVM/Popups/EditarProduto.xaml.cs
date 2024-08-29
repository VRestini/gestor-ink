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