using AppGestorInk.MVVM.ViewModels;


namespace AppGestorInk.MVVM.Popups;

public partial class AddItemPop : ContentPage
{
    public AddItemPop (AddItemViewModel addItemViewModel)
    {
        InitializeComponent();
        BindingContext = addItemViewModel;
        datePicker.Date = DateTime.Now;
    }
    private async void EditorWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {
        BorderPrice.Stroke = Colors.LightGray;   
    }
    private async void EditorWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        BorderPrice.Stroke = Color.FromArgb("#4C007D");       
    }
    private async void EntryWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {
        BorderQtd.Stroke = Colors.LightGray;      
    }
    private async void EntryWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        BorderQtd.Stroke = Color.FromArgb("#4C007D");      
    }
    
}