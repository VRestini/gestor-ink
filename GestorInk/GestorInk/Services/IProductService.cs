using GestorInk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Services
{
    public interface IProductService
    {
        Task Init() ;
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProductByName(string productName);
        Task CreateProduct(Product product);
        Task RefreshProduct(Product product);
        
        Task DeleteProduct(Product product);

    }
}
