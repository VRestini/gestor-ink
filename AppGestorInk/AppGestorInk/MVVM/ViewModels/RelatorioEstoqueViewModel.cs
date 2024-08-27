using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.Popups;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace AppGestorInk.MVVM.ViewModels
{
    [QueryProperty(nameof(Produto), "ProdutoObject")]
    public partial class RelatorioEstoqueViewModel: ObservableObject
    {
        public readonly IServiceItem _serviceItem;
      
        public ObservableCollection<ItemProduto> ItemProdutoList { get; set; } = new();
        private readonly EstoqueViewModel _estoqueViewModel;
        
        [ObservableProperty]
        private Produto _produto;

        public RelatorioEstoqueViewModel(IServiceItem serviceItem, EstoqueViewModel estoqueViewModel)
        {
            _serviceItem = serviceItem;
            _estoqueViewModel = estoqueViewModel;
            


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
                        if(itemProduto.Name == Produto.Name)
                        {
                            ItemProdutoList.Add(itemProduto);
                        }
                        
                    }

                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async Task AddItem(Produto produto)
        {
            var uri = $"{nameof(AddItemPop)}?id=0";
            await Shell.Current.GoToAsync(uri, new Dictionary<string, object>
            {
                { "ProdutoObject", produto }
            });
        }
        [RelayCommand]
        private async Task DeleteItemProduto(ItemProduto itemProduto)
        {
            bool option = await Shell.Current.DisplayAlert("Deletar", "a", "Sim", "Não");
            if (option is true)
            {
                try
                {
                    await _serviceItem.InitializeAsync();
                    await _serviceItem.DeleteItemProdutoAsync(itemProduto);
                    await Shell.Current.DisplayAlert("Sucesso", "Produto excluido", "ok");
                    await GetItemProduto();
                }
                catch
                (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
                }
            }
        }
    }
}
