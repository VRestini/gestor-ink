using GestorInk.Services;
using GestorInk.ViewModel;
using GestorInk.ViewModel.ViewModelScheduler;
using GestorInk.ViewModel.ViewModelStockProduct;

namespace GestorInk.Page.StockProductPage;

public partial class StockProductFeed : ContentPage
{

	public StockProductFeed(StockProductFeedVM stockProductFeedVM)
	{
		InitializeComponent();
		BindingContext = stockProductFeedVM;

	}
}