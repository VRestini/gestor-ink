using AppGestorInk.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppGestorInk.MVVM.Models;

namespace AppGestorInk.MVVM.ViewModels
{
    public partial class AddProdutoViewModel : ObservableObject
    {
        private readonly IProdutoService _produtoService;
        [ObservableProperty]
        public string _produtoName;
        [ObservableProperty]
        public string _produtoDescricao;
        

        public AddProdutoViewModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        
        
        [RelayCommand]
        private async Task AddProduto()
        {
            try
            {
                if (!string.IsNullOrEmpty(ProdutoName)) // verifica se o nome foi informado
                {
                    Produto produto = new()
                    {
                        Name = ProdutoName,
                        Descricao = ProdutoDescricao,
                        
                    };
                    await _produtoService.InitializeAsync();
                    await _produtoService.AddProdutoAsync(produto);

                    await Shell.Current.GoToAsync(".."); // voltar para a página anterior
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Livro sem Título", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }


        }
    }
}
