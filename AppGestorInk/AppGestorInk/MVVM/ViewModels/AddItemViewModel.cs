using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AppGestorInk.MVVM.ViewModels
{
    [QueryProperty(nameof(Produto), "ProdutoObject")]
    public partial class AddItemViewModel:ObservableObject
    {
        private readonly IServiceItem _serviceItem;
        [ObservableProperty]
        public int _itemQuantidade;
        [ObservableProperty]
        public double _itemPreco;
        [ObservableProperty]
        public DateTime _itemValidade;
        [ObservableProperty]
        private Produto _produto;

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
                        Name = Produto.Name,
                        Descricao = Produto.Descricao,
                        Quantidade = ItemQuantidade,
                        Preco = ItemPreco,
                        DataValidade = ItemValidade,
                    };
                    await _serviceItem.InitializeAsync();
                    for (int i = 1; i <= _itemQuantidade - 1; i++)
                    {
                        await _serviceItem.AddItemProdutoAsync(itemProduto);
                       

                    }
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
