using GestorInk.ViewModel.ViewModelProduct;

namespace GestorInk.Page.ProductPage;

public partial class ProductCreate : ContentPage
{
    public ProductCreate(ProductCreateVM productCreateVM)
    {
        InitializeComponent();
        BindingContext = productCreateVM;

    }

}