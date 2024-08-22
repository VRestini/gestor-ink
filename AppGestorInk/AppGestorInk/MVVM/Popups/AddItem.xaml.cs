using AppGestorInk.MVVM.ViewModels;

namespace AppGestorInk.MVVM.Popups;

public partial class AddItem : ContentPage
{
	public AddItem(AddItemViewModel addItemViewModel)
	{
		InitializeComponent();
		BindingContext = addItemViewModel;
	}
}