using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GestorInk.Models;
using GestorInk.Page.ProductPage;
using GestorInk.Page.StockProductPage;
using GestorInk.Services;
using System.Collections.ObjectModel;


namespace GestorInk.ViewModel.ViewModelProduct
{
    public partial class ProductFeedVM : ObservableObject
    {
        IProductService _productService;
        public ObservableCollection<Product> ProductList { get; set; } = new();
        public ProductFeedVM(IProductService productService)
        {
            _productService = productService;
            SetInitDatabase();          
        }
        [RelayCommand]
        public async Task SetInitDatabase()
        {
            await _productService.Init();
        }
        [RelayCommand]
        public async Task GetAllProduct()
        {         
            ProductList.Clear();            
            try
            {
                var list = await _productService.GetAllProducts();
                if (list.Any())
                {
                    foreach (var product in list)
                    {
                        ProductList.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        [RelayCommand]
        public async Task GetProductByName(string nome)
        {
            ProductList.Clear();
            try
            {
                var list = await _productService.GetProductByName(nome);
                if (list.Any())
                {
                    foreach (var produto in list)
                    {
                        ProductList.Add(produto);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        [RelayCommand]
        public async Task CreateProduct()
        {
            var uri = $"{nameof(ProductCreate)}";
            await Shell.Current.GoToAsync(uri);
                  
        }   
        [RelayCommand]
        public async Task UpdateProduct(Product product)
        {
            var uri = $"{nameof(ProductEditor)}";  
            await Shell.Current.GoToAsync(uri, new Dictionary<string, object>
            {
                { "ProductObject", product }  
            });
        }
        [RelayCommand]
        public async Task ListStockProduct(Product product)
        {
            await Shell.Current.GoToAsync($"{nameof(StockProductFeed)}", new Dictionary<string, object>
                {
                    { "fProduct", product } 
                });
        }
    }
}
