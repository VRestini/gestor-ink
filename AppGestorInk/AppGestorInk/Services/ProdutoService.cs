using SQLite;
using AppGestorInk.MVVM.Models;
namespace AppGestorInk.Services
{
    public class ProdutoService : IProdutoService
    {
        private SQLiteAsyncConnection _dbConnectionA; // conexão com o sqlite
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb() // configura o serviço sqlite
        {
            if (_dbConnectionA == null) // se nn existir conexão ele cria, juntamente da tabela
            {
                string dbPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProdutoDB.db3"); // definir caminho

                _dbConnectionA = new SQLiteAsyncConnection(dbPath);
                await _dbConnectionA.CreateTableAsync<Produto>();
            }
        }
        public async Task<int> AddProdutoAsync(Produto produto)
        {
            return await _dbConnectionA.InsertAsync(produto);

        }
        public async Task DeleteAllItemsByProdutoAsync(int produtoId)
        {
            // Obtemos a lista de todos os ItemProduto associados ao Produto
            var items = await _dbConnectionA.Table<ItemProduto>()
                                               .Where(i => i.ProdutoId == produtoId)
                                               .ToListAsync();

            // Deletamos todos os itens associados
            foreach (var item in items)
            {
                await _dbConnectionA.DeleteAsync(item);
            }
        }
        public async Task<int> DeleteProdutoAsync(Produto produto)
        {
            await DeleteAllItemsByProdutoAsync(produto.Id);
            return await _dbConnectionA.DeleteAsync(produto);
        }
        public async Task<int> RefreshProdutoAsync(Produto produto)
        {
            return await _dbConnectionA.UpdateAsync(produto);
        }

        public async Task<IEnumerable<Produto>> GetProdutoAsync()
        {
            var produtos = await _dbConnectionA.Table<Produto>().ToListAsync();
            return produtos;
        }

        public async Task<IEnumerable<Produto>> GetProdutoNomeAsync(string nome)
        {
            var produtos = await _dbConnectionA.Table<Produto>().Where(x => x.Name.Contains(nome)).ToListAsync();
            return produtos;
        }
        
    }
}
