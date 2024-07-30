using CommunityToolkit.Maui.Views;
namespace AppGestorInk.MVVM.Popups;

public partial class CriarProduto : Popup
{
	public CriarProduto()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}