using SQLite;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Models
{
    [Table ("PRODUCT_USED")]
    public class ProductStockUsed :Product
    {
        [PrimaryKey, AutoIncrement]
        public int ProductStockUsedId { get; set; }
        [NotNull]
        public DateTime DtExclude { get; set; }
        [NotNull]
        public int FKProductStockId { get; set; }
    }
}
