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
        public DateTime ProductStockDateCreate { get; set; }
        [NotNull]
        public DateTime ProductStockDateValidity { get; set; }
        [NotNull]
        public double ProductStockPrice { get; set; }

        public int FKProductId { get; set; }

    }
}
