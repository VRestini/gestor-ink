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
    internal class StockProductRepository : IStockProductService
    {
        private SQLiteAsyncConnection _dbconnection;
        public async Task Init()
        {
            if (_dbconnection != null)
                return;
            _dbconnection = new SQLiteAsyncConnection(ConstantsDB.DatabasePath, ConstantsDB.Flags);
            await _dbconnection.CreateTableAsync<ProductStock>();
        }
        public async Task<IEnumerable<ProductStock>> GetAllStockProducts()
        {
            await Init();
            return await _dbconnection.Table<ProductStock>().ToListAsync();
        }
        public async Task CreateStockroduct(ProductStock productStock)
        {
            await _dbconnection.InsertAsync(productStock);
        }                              
        public async Task UpdateStockProduct(ProductStock productStock)
        {
            await _dbconnection.UpdateAsync(productStock);
        }        
    }
}
