using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorInk.Models;
using GestorInk.Page.StockProductPage;
using GestorInk.Services;

using System.Collections.ObjectModel;

namespace GestorInk.ViewModel.ViewModelStockProduct
{
    [QueryProperty(nameof(Product), "ProductObject")]
    public partial class StockProductFeedVM: ObservableObject
    {
        IStockProductService _stockProductService;
        public ObservableCollection<ProductStockUsed> ProductStockListUsed { get; set; } = new();
        public ObservableCollection<ProductStock> ProductStockList { get; set; } = new();
        [ObservableProperty]
        private string _tituloBotao = "USADOS";
        [ObservableProperty]
        private bool _listAvailable;
        [ObservableProperty]
        private bool _listUsed;
        [ObservableProperty]
        public Product _productProperty;
        [ObservableProperty]
        public String _switchTextButton;
        public int id;

        public StockProductFeedVM(IStockProductService stockProductService)
        {
            _stockProductService = stockProductService;
            SetInitDatabase();
            _listAvailable = true;
            _listUsed = false;
   
        }
        public async Task SetInitDatabase()
        {
            await _stockProductService.Init();
        }
        [RelayCommand]
        public async Task SwitchList()
        {
            if (SwitchTextButton == "DISPONÍVEIS")
            {
                SwitchTextButton = "USADOS";
                await GetProductCommand.ExecuteAsync(null);
            }
            else
            {
                SwitchTextButton = "DISPONÍVEIS";
                await GetProductUsedCommand.ExecuteAsync(id);
            }
        }
        [RelayCommand]
        public async Task GetProduct()
        {
            ProductStockList.Clear();
            ProductStockListUsed.Clear();
            try
            {
                var list = await _stockProductService.GetAllStockProducts(ProductProperty.ProductId);
                if (list.Any())
                {
                    foreach (var product in list)
                    {
                        ProductStockList.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
            }
            
        }
        [RelayCommand]
        public async Task GetProductUsed()
        {
            ProductStockList.Clear();
            ProductStockListUsed.Clear();
            try
            {
                var list = await _stockProductService.GetAllStockProductsUsed(ProductProperty.ProductId);
                if (list.Any())
                {
                    foreach (var product in list)
                    {
                        ProductStockListUsed.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        public async Task DeleteProductStock(ProductStock productStock)
        {
            try
            {
                bool option = await Shell.Current.DisplayAlert("Você deseja excluir esse produto?",
                "Ao excluir o produto não será possível recuperá-lo!", "Sim", "Não");
                if (option)
                {
                    var i = new ProductStockUsed
                    {
                        DtExclude = DateTime.Now,
                        FKProductStockId = ProductProperty.ProductId
                    };
                    ProductStockListUsed.Add(i);
                    ProductStockList.Remove(productStock);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
            }
            
            
        }
        [RelayCommand]
        public async Task CreateProductStock()
        {
            var uri = $"{nameof(StockProductCreate)}";
            await Shell.Current.GoToAsync(uri);
        }

    }
}
