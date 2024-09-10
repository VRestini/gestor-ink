using AppGestorInk.MVVM.Models;
namespace AppGestorInk.Services
{
    public interface IProdutoService
    {
        Task InitializeAsync();
        Task<IEnumerable<Produto>> GetProdutoAsync();
        Task<IEnumerable<Produto>> GetProdutoNomeAsync(string produto);
        Task<int> AddProdutoAsync(Produto produto);
        Task<int> DeleteProdutoAsync(Produto produto);
        Task DeleteAllItemsByProdutoAsync(int produtoId);
        Task<int> RefreshProdutoAsync(Produto produto);
    }
}
