using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorInk.Models;
using GestorInk.Page.StockProductPage;
using GestorInk.Services;

using System.Collections.ObjectModel;

namespace GestorInk.ViewModel.ViewModelStockProduct
{
    [QueryProperty(nameof(FProduct), "fProduct")]
    public partial class StockProductFeedVM: ObservableObject
    {
        IStockProductService _stockProductService;
        public ObservableCollection<ProductStockUsed> ProductStockListUsed { get; set; } = new();
        public ObservableCollection<ProductStock> ProductStockList { get; set; } = new();
      
        [ObservableProperty]
        private bool _listAvailable;
        [ObservableProperty]
        private bool _listUsed;
       
        [ObservableProperty]
        private Product _fProduct;
        [ObservableProperty]
        public String _switchTextButton;
      

        public StockProductFeedVM(IStockProductService stockProductService)
        {
            _stockProductService = stockProductService;
            SetInitDatabase();
            _listAvailable = true;
            _listUsed = false;
            SwitchTextButton = "USADOS";

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
                await GetProductUsedCommand.ExecuteAsync(null);
            }
        }
        [RelayCommand]
        public async Task GetProduct()
        {
            ProductStockList.Clear();
            ProductStockListUsed.Clear();
            try
            {
                var list = await _stockProductService.GetAllStockProducts(FProduct.ProductId);
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
                var list = await _stockProductService.GetAllStockProductsUsed(FProduct.ProductId);
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
        [RelayCommand]
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
                        FKProductStockId = FProduct.ProductId
                    };
                    
                    
   
                    await _stockProductService.DeleteStockProduct(productStock);
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
            await Shell.Current.GoToAsync($"{nameof(StockProductCreate)}", new Dictionary<string, object>
                {
                    { "fProduct", FProduct }
                });
          
        }

    }
}
