using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorInk.Models;
using GestorInk.Page.ProductPage;
using GestorInk.Services;


namespace GestorInk.ViewModel.ViewModelProduct
{
    [QueryProperty(nameof(Product), "ProductObject")]
    public partial class ProductEditorVM : ObservableObject
    {
        private readonly IProductService _productService;

        [ObservableProperty]
        private Product _productProperty;
        private Product _product;
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                ProductProperty = _product; // Atualiza a propriedade vinculada ao XAML
            }
        }
        public ProductEditorVM(IProductService productService)
        {
            _productService = productService;
            SetInitDatabase();
        }        
        public async Task SetInitDatabase()
        {
            await _productService.Init();
        }
        [RelayCommand]
        public async Task DeleteProduct(Product product)
        {
            if (product == null)
            {
                await Shell.Current.DisplayAlert("Erro!", "Produto inválido!", "Ok");
                return;
            }

            bool option = await Shell.Current.DisplayAlert("Você deseja excluir esse produto?",
                "Ao excluir o produto não será possível recuperá-lo!", "Sim", "Não");

            if (option)
            {
                await _productService.Init();
                await _productService.DeleteProduct(product);
                await Shell.Current.GoToAsync("//productfeed");
            }
        }

        [RelayCommand]
        public async Task RefreshProductEditor()
        {
            if (ProductProperty == null)
            {
                await Shell.Current.DisplayAlert("Erro!", "Nenhum produto selecionado!", "Ok");
                return;
            }

            await _productService.RefreshProduct(ProductProperty);
            System.Diagnostics.Debug.WriteLine("Refresh of product was successful.");
            await Shell.Current.GoToAsync("//productfeed");
        }
    }
}
