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
        
        [ObservableProperty]
        private string _tituloBotao = "MATERIAIS USADOS";
        [ObservableProperty]
        private bool _listDisponiveis;
        [ObservableProperty]
        private bool _listUsados;
        [ObservableProperty]
        private ObservableCollection<ItemProdutoUsado> _itemProdutoUsadosList = new ObservableCollection<ItemProdutoUsado>();
        public ObservableCollection<ItemProduto> ItemProdutoList { get; set; } = new ObservableCollection<ItemProduto>();
        private readonly EstoqueViewModel _estoqueViewModel;
        
        [ObservableProperty]
        private Produto _produto;

        public RelatorioEstoqueViewModel(IServiceItem serviceItem, EstoqueViewModel estoqueViewModel)
        {
            _serviceItem = serviceItem;
            
            _estoqueViewModel = estoqueViewModel;           
            _listDisponiveis = true;
            _listUsados = false;

        }
        [RelayCommand]
        public async Task MudarList()
        {
            if (TituloBotao == "MATERIAIS USADOS")
            {
                TituloBotao = "MATERIAIS DISPONÍVEIS"; // Atualizar o título do botão
                await GetItemProdutoUsadosCommand.ExecuteAsync(null); // Carregar materiais usados
            }
            else
            {
                TituloBotao = "MATERIAIS USADOS"; // Atualizar o título do botão
                await GetItemProdutoCommand.ExecuteAsync(null); // Carregar materiais disponíveis
            }
            ListDisponiveis = !ListDisponiveis; 
            ListUsados = !ListUsados;
        }
        [RelayCommand]

        public async Task GetItemProduto()
        {
            ItemProdutoList.Clear();
            try
            {
                
                await _serviceItem.InitializeAsync();
                
                var itemProdutos = await _serviceItem.GetItemProdutoByProdutoIdAsync(Produto.Id);
                foreach (var itemProduto in itemProdutos)
                {
                    ItemProdutoList.Add(itemProduto);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        public async Task GetItemProdutoUsados()
        {
            try
            {
                ItemProdutoUsadosList.Clear();
                await _serviceItem.InitializeAsync();

                var itensUsados = await _serviceItem.GetItemProdutosUsadosAsync();
                foreach (var itemm in itensUsados)
                {
                    ItemProdutoUsadosList.Add(itemm);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
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
            bool option = await Shell.Current.DisplayAlert("Deletar", "Deseja deletar o produto?", "Sim", "Não");
            if (option)
            {
                try
                {
                    await _serviceItem.InitializeAsync();

                    // Salvar o item como usado
                    var itemProdutoUsado = new ItemProdutoUsado
                    {
                        ProdutoId = itemProduto.ProdutoId,
                        Name = itemProduto.Name,
                        Preco = itemProduto.Preco,
                        Quantidade = itemProduto.Quantidade,
                        DataValidade = itemProduto.DataValidade,
                        Foto = itemProduto.Foto,
                        DataExclusao = DateTime.Now
                    };
                    await _serviceItem.AddItemProdutoUsadoAsync(itemProdutoUsado);
                    ItemProdutoUsadosList.Add(itemProdutoUsado);

                    // Deletar o item da tabela original
                    await _serviceItem.DeleteItemProdutoAsync(itemProduto);
                    ItemProdutoList.Remove(itemProduto);

                    await Shell.Current.DisplayAlert("Sucesso", "Produto excluído e salvo como usado.", "OK");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
                }
            }
        }

    }
}
