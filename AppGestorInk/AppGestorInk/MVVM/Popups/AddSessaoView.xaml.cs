using AppGestorInk.MVVM.ViewModels;
using Syncfusion.Maui.Picker;

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

    private void pickerButton_Clicked(object sender, EventArgs e)
    {
        this.DatePicker.IsOpen = true;
    }

    private void DatePicker_SelectionChanged(object sender, Syncfusion.Maui.Picker.DateTimePickerSelectionChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            DateTime selectedDate = (DateTime)e.NewValue;

            var viewModel = (AddSessaoViewModel)BindingContext;
            viewModel.SessaoDate = selectedDate; // Atualiza a data selecionada
        }
    }

    private void Label_Focused(object sender, FocusEventArgs e)
    {
        BorderDate.Stroke = Color.FromArgb("#4C007D");
        BorderDate.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private void Label_Unfocused(object sender, FocusEventArgs e)
    {
        BorderDate.Stroke = Colors.LightGray;
        BorderDate.BackgroundColor = Colors.LightGray;
    }

    private void EntryWithoutBorder_Focused_1(object sender, FocusEventArgs e)
    {
        BorderNameCliente.Stroke = Color.FromArgb("#4C007D");
        BorderNameCliente.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private void EntryWithoutBorder_Unfocused_1(object sender, FocusEventArgs e)
    {
        BorderNameCliente.Stroke = Colors.LightGray;
        BorderNameCliente.BackgroundColor = Colors.LightGray;
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
