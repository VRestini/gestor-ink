using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AddItemViewModel:ObservableObject
    {
        private readonly IServiceItem _serviceItem;
        [ObservableProperty]
        public int _itemQuantidade;
        [ObservableProperty]
        public double _itemPreco;

        public AddItemViewModel(IServiceItem serviceItem)
        {
            _serviceItem = serviceItem;
        }
        [RelayCommand]
        private async Task AddItem()
        {
            try
            {
                if (ItemQuantidade != 0) // verifica se o nome foi informado
                {
                    ItemProduto itemProduto = new()
                    {
                        Quantidade = ItemQuantidade,
                        Preco = ItemPreco
                    };
                    await _serviceItem.InitializeAsync();
                    await _serviceItem.AddItemProdutoAsync(itemProduto);
                    await Shell.Current.DisplayAlert("Sucesso", "Mensagem", "OK");

                    await Shell.Current.GoToAsync(".."); // voltar para a página anterior
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Mensagem erro", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


        }
    }
}
