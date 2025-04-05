using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Models
{
    [Table("PRODUCT_STOCK")]
    public class ProductStock : Product
    {
        [PrimaryKey, AutoIncrement]
        private int ProductStockId { get; set; }
        [NotNull]
        private DateTime ProductStockDateCreate { get; set; }
        [NotNull]
        private DateTime ProductStockDateValidity { get; set; }
        [NotNull]
        private double ProductStockPrice { get; set; }
        
        [NotNull]
        public int FKProductId { get; set; }

    }
}
