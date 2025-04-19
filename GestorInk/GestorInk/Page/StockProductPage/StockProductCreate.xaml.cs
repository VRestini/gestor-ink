using GestorInk.ViewModel.ViewModelStockProduct;

namespace GestorInk.Page.StockProductPage;

public partial class StockProductCreate : ContentPage
{
	public StockProductCreate(StockProductCreateVM stockProductCreateVM)
	{
		InitializeComponent();
		BindingContext = stockProductCreateVM;
	}
}