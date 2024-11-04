
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
        BorderDescription.BackgroundColor = Colors.LightGray; 
    }
    
    private async void EditorWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        BorderDescription.Stroke = Color.FromArgb("#4C007D");
        BorderDescription.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private async void EntryWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {
        BorderName.Stroke = Colors.LightGray;
        BorderName.BackgroundColor = Colors.LightGray;
    }

    private async void EntryWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        
        BorderName.Stroke = Color.FromArgb("#4C007D");
        BorderName.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
       
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Teste",
                FileTypes = FilePickerFileType.Images
            });
            if (result == null)
                return;
            var stream = await result.OpenReadAsync();
            MyImage.Source = ImageSource.FromStream(() => stream);

        
    }
}