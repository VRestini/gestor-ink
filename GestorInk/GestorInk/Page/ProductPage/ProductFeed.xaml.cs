using GestorInk.Services;

using GestorInk.ViewModel.ViewModelProduct;

namespace GestorInk.Page.ProductPage;

public partial class ProductFeed : ContentPage
{
    private readonly IProductService _productService;
    public ProductFeed(ProductFeedVM productFeedVM, IProductService productService)
	{
		InitializeComponent();
        BindingContext = productFeedVM;
        _productService = productService;
        NavigationPage.SetHasBackButton(this, false);
    }
}