using AppGestorInk.MVVM.Models;
using SQLite;


namespace AppGestorInk.Services
{
    public class ItemService : IServiceItem
    {
        private SQLiteAsyncConnection _dbItemConnection;
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb() // configura o serviço sqlite
        {
            if (_dbItemConnection == null) // se nn existir conexão ele cria, juntamente da tabela
            {
                string dbPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ItemProdutoDB.db3"); // definir caminho

                _dbItemConnection = new SQLiteAsyncConnection(dbPath);
                await _dbItemConnection.CreateTableAsync<ItemProduto>();
            }
        }
        public async Task<IEnumerable<ItemProduto>> GetItemProdutoByProdutoIdAsync(int produtoId)
        {
            return await _dbItemConnection.Table<ItemProduto>()
                                          .Where(i => i.ProdutoId == produtoId)
                                          .ToListAsync();
        }
        public async Task<IEnumerable<ItemProduto>> GetItemProdutoAsync()
        {
            var itemProduto = await _dbItemConnection.Table<ItemProduto>().ToListAsync();
            return itemProduto;
        }

        public async Task<IEnumerable<ItemProduto>> GetItemProdutoNameAsync(string itemProduto)
        {
            throw new NotImplementedException();
        }
        public async Task<int> AddItemProdutoAsync(ItemProduto itemProduto)
        {
            
            return await _dbItemConnection.InsertAsync(itemProduto);
        }

        public async Task<int> DeleteItemProdutoAsync(ItemProduto itemProduto)
        {
            return await _dbItemConnection.DeleteAsync(itemProduto);
        }
        public async Task<int> RefreshItemProdutoAsync(ItemProduto itemProduto)
        {
            return await _dbItemConnection.UpdateAsync(itemProduto);
        }
    }
}
