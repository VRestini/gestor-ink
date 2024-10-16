using AppGestorInk.MVVM.ViewModels;

namespace AppGestorInk.MVVM.Popups;

public partial class AddSessaoView : ContentPage
{
	public AddSessaoView(AddSessaoViewModel addSessaoViewModel)
	{
		InitializeComponent();
        BindingContext = addSessaoViewModel;
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