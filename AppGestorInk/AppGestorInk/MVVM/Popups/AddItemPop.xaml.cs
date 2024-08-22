using AppGestorInk.MVVM.ViewModels;

namespace AppGestorInk.MVVM.Popups;

public partial class AddItemPop : ContentPage
{
    public AddItemPop (AddItemViewModel addItemViewModel)
    {
        InitializeComponent();
        BindingContext = addItemViewModel;
    }
}