using SQLite;
using AppGestorInk.MVVM.Models;
namespace AppGestorInk.Services
{
    public class ProdutoService : IProdutoService
    {
        private SQLiteAsyncConnection _dbConnection; // conexão com o sqlite
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb() // configura o serviço sqlite
        {
            if (_dbConnection == null) // se nn existir conexão ele cria, juntamente da tabela
            {
                string dbPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProdutoDB.db3"); // definir caminho

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Produto>();
            }
        }
        public async Task<int> AddProdutoAsync(Produto produto)
        {
            return await _dbConnection.InsertAsync(produto);
        }

        public async Task<int> DeleteProdutoAsync(Produto produto)
        {
          
            return await _dbConnection.DeleteAsync(produto);
        }
        public async Task<int> RefreshProdutoAsync(Produto produto)
        {
            return await _dbConnection.UpdateAsync(produto);
        }

        public async Task<IEnumerable<Produto>> GetProdutoAsync()
        {
            var produtos = await _dbConnection.Table<Produto>().ToListAsync();
            return produtos;
        }

        public async Task<IEnumerable<Produto>> GetProdutoNomeAsync(string nome)
        {
            var produtos = await _dbConnection.Table<Produto>().Where(x => x.Name.Contains(nome)).ToListAsync();
            return produtos;
        }
        
    }
}
