using AppGestorInk.MVVM.ViewModels;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;

namespace AppGestorInk.MVVM.Popups;

public partial class MenuPopup : Popup
{
	public MenuPopup()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
         Close();
         var uri = $"{nameof(AddProdutoPop)}?id=0";
         Shell.Current.GoToAsync(uri);
      
    }
}