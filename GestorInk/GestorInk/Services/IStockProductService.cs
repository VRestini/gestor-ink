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
        Task<IEnumerable<ProductStock>> GetAllStockProducts();     
        Task CreateStockroduct(ProductStock productStock);
        Task UpdateStockProduct(ProductStock productStock);

    }
}
