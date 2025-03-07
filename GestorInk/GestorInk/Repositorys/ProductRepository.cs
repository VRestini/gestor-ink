using GestorInk.Data;
using GestorInk.Models;
using GestorInk.Services;
using SQLite;


namespace GestorInk.Repositorys
{    internal class ProductRepository : IProductService
    {        
        private SQLiteAsyncConnection _dbconnection;
        public async Task Init()
        {
            try
            {
                if (_dbconnection != null)
                    return;

                _dbconnection = new SQLiteAsyncConnection(ConstantsDB.DatabasePath, ConstantsDB.Flags);
                await _dbconnection.CreateTableAsync<Product>();
                System.Diagnostics.Debug.WriteLine("Database of product was initialized successfully.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error initializing database: {ex.Message}");
            }

        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                if (_dbconnection == null)
                {
                    System.Diagnostics.Debug.WriteLine("Database connection is null.");
                    return new List<Product>();
                }
                var list = await _dbconnection.Table<Product>().ToListAsync();
                System.Diagnostics.Debug.WriteLine($"Retrieved {list.Count} products.");
                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error retrieving products: {ex.Message}");
                return new List<Product>();
            }
        }
        public async Task CreateProduct(Product product)
        {
            try
            {
                if (_dbconnection == null)
                {
                    await Init();
                }
                await _dbconnection.InsertAsync(product);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating products: {ex.Message}");
            }
            
        }
        public async Task RefreshProduct(Product product)
        {
            try
            {
                if (_dbconnection == null)
                {
                    await Init();
                }
                await _dbconnection.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating products: {ex.Message}");
            }
            
        }
        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            try
            {
                if (_dbconnection == null)
                {
                    System.Diagnostics.Debug.WriteLine("Database connection is null.");
                    await Init();
                }
                var list = await _dbconnection.Table<Product>().Where(x => x.ProductName.Equals(productName)).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error retrieving products: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task DeleteProduct(Product product)
        {
            try
            {
                if (_dbconnection == null)
                {
                    await Init();
                }
                if( product != null)
                {
                    await _dbconnection.DeleteAsync(product);
                }
                    
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting products at: {ex.Message}");
            }
        }

        /*public async Task <IEnumerable<Product>> GetProductByName(string productName)
        {
            var listProducts = await _dbconnection.Table<Product>().Where(x => x.).ToListAsync();
            return listProducts;
        }*/
    }
}
