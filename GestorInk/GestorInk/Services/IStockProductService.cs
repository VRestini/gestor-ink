using GestorInk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Services
{
    public interface IStockProductService
    {
        Task Init();
        Task<IEnumerable<ProductStock>> GetAllStockProducts(int fk);
        Task<IEnumerable<ProductStockUsed>> GetAllStockProductsUsed(int fk);
        Task CreateStockProduct(ProductStock productStock);
        Task CreateStockProductUsed(ProductStockUsed productStockUsed);
        Task DeleteStockProduct(ProductStock productStock);
    }
}
