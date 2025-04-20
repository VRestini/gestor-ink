using GestorInk.Data;
using GestorInk.Models;
using GestorInk.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Repositorys
{
    public class StockProductRepository : IStockProductService
    {
        private SQLiteAsyncConnection _dbconnection;
        public async Task Init()
        {
            if (_dbconnection != null)
                return;
            _dbconnection = new SQLiteAsyncConnection(ConstantsDB.DatabasePath, ConstantsDB.Flags);
            await _dbconnection.CreateTableAsync<ProductStock>();
            await _dbconnection.CreateTableAsync<ProductStockUsed>();
        }
        public async Task<IEnumerable<ProductStock>> GetAllStockProducts(int id)
        {
            await Init();
            return await _dbconnection.Table<ProductStock>().Where(i => i.FKProductId == id).ToListAsync();
        }
        public async Task<IEnumerable<ProductStockUsed>> GetAllStockProductsUsed(int id)
        {
            await Init();
            return await _dbconnection.Table<ProductStockUsed>().Where(i => i.FKProductStockId == id).ToListAsync();
        }
        public async Task CreateStockProduct(ProductStock productStock)
        {
            await Init();
            await _dbconnection.InsertAsync(productStock);
        }

        public async Task CreateStockProductUsed(ProductStockUsed productStockUsed)
        {
            await Init();
            await _dbconnection.InsertAsync(productStockUsed);
        }

        public async Task DeleteStockProduct(ProductStock productStock)
        {
            await Init();
            await _dbconnection.DeleteAsync(productStock);
        }
    }
}
