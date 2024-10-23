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
        public string _itemQuantidade;
        [ObservableProperty]
        public string _itemPreco;
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
                if (int.TryParse(ItemQuantidade, out int quantidade) && double.TryParse(ItemPreco, out double preco))
                {
                    if (quantidade != 0 && preco != 0.00)
                    {

                        ItemProduto itemProduto = new()
                        {
                            ProdutoId = Produto.Id,
                            Name = Produto.Name,
                            Descricao = Produto.Descricao,
                            Quantidade = quantidade,
                            Preco = preco,
                            DataValidade = ItemValidade,
                        };
                        await _serviceItem.InitializeAsync();
                        for (int i = 1; i <= quantidade - 1; i++)
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
