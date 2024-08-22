using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.Popups;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace AppGestorInk.MVVM.ViewModels
{
    public partial class RelatorioEstoqueViewModel: ObservableObject
    {
        public readonly IServiceItem _serviceItem;
        public ObservableCollection<ItemProduto> ItemProdutoList { get; set; } = new();

        public RelatorioEstoqueViewModel(IServiceItem serviceItem)
        {
            _serviceItem = serviceItem;
        }
        [RelayCommand]

        public async Task GetItemProduto()
        {
            ItemProdutoList.Clear();
            try
            {
                await _serviceItem.InitializeAsync();
                var itemProdutos = await _serviceItem.GetItemProdutoAsync();
                if (itemProdutos.Any())
                {
                    foreach (var itemProduto in itemProdutos)
                    {
                        ItemProdutoList.Add(itemProduto);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async Task AddItem()
        {
            var uri = $"{nameof(AddItemPop)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }

    }
}
