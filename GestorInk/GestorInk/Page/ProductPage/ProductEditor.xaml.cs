using GestorInk.ViewModel.ViewModelProduct;

namespace GestorInk.Page.ProductPage;

public partial class ProductEditor : ContentPage
{
	public ProductEditor(ProductEditorVM productEditorVM)
	{
		InitializeComponent();
		BindingContext = productEditorVM;
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