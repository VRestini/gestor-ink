
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorInk.Models;
using GestorInk.Page.ProductPage;
using GestorInk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.ViewModel.ViewModelProduct
{
    
    public partial class ProductCreateVM : ObservableObject
    {
        IProductService _productService;      
        [ObservableProperty]
        public string _productNameProperty;
        [ObservableProperty]
        public string _productDescriptionProperty;
        [ObservableProperty]
        public string _productPhotoPathProperty;
        [ObservableProperty]
        public bool _productIsConsumableProperty;
        [ObservableProperty]
        public int _productAmountAlertProperty;

        public ProductCreateVM(IProductService productService)
        {
            _productService = productService;
        }
        [RelayCommand]
        public async Task CreateProduct()
        {
            if (!string.IsNullOrEmpty(ProductNameProperty))
            {
                if(ProductNameProperty.Length <= 50)
                {
                    Product product = new Product()
                    {
                        ProductName = ProductNameProperty,
                        ProductDescription = ProductDescriptionProperty,
                        ProductPhotoPath = ProductPhotoPathProperty,
                        ProductAmountAlert = ProductAmountAlertProperty,
                        ProductIsConsumable = ProductIsConsumableProperty,
                    };

                    await _productService.CreateProduct(product);

                    await Shell.Current.GoToAsync("//productfeed");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Erro!", "O nome deve conter no máximo 50 caracteres", "Ok");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro!", "Insira um nome!", "Ok");
            }
        }
    }
}
