using SQLite;
using AppGestorInk.MVVM.Models;
namespace AppGestorInk.Services
{
    public class ProdutoService
    {
        private readonly SQLiteAsyncConnection _bd;
        public ProdutoService()
        {
            var localDb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "produto.db3"); // pra localizar a tabela no banco
            _bd = new SQLiteAsyncConnection(localDb); // criar conexão com o banco
            _bd.CreateTableAsync<Produto>().Wait(); // criar a tabela
        }
        public Task<int> CriarProduto(Produto produto)
        {
            return _bd.InsertAsync(produto); //InsertAsync é o método do sqlite pra adicionar
        }
        public Task<List<Produto>> ListarProduto()
        {
            return _bd.Table<Produto>().ToListAsync();
        }
    }
}
