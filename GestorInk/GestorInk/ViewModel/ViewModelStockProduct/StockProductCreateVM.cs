using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorInk.Models;
using GestorInk.Services;


namespace GestorInk.ViewModel.ViewModelStockProduct
{
    [QueryProperty(nameof(FProduct), "fProduct")]
    public partial class StockProductCreateVM : ObservableObject
    {
        IStockProductService _stockProductService { get; set; }
        [ObservableProperty]
        public DateTime _stockDateValidity;
        [ObservableProperty]
        public DateTime _stockDateCreate;
        [ObservableProperty]
        public double _stockPrice;
        [ObservableProperty]
        public double _amount;
        [ObservableProperty]
        private Product _fProduct;

        public StockProductCreateVM(IStockProductService stockProductService)
        {
            _stockProductService = stockProductService;
            _stockProductService.Init();
        }
        [RelayCommand]
        public async Task CreateStockProduct()
        {
            try
            {
                if (Amount >= 0 && StockPrice >= 0.00) {
                    ProductStock i = new()
                    {
                        FKProductId = FProduct.ProductId,
                        ProductName = FProduct.ProductName,
                        ProductStockDateCreate = DateTime.Now,
                        ProductStockDateValidity = StockDateValidity,
                        ProductStockPrice = StockPrice,
                    };
                    for (int j = 1; j <= Amount; j++)
                    {
                        await _stockProductService.CreateStockProduct(i);                        
                    }
                    await Shell.Current.DisplayAlert("Sucesso", "Mensagem", "OK");
                    //await Shell.Current.GoToAsync("//stockproductfeed");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Erro", "Preencha corretamente os campos de Quantidade e Preço", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }   
    }
}
