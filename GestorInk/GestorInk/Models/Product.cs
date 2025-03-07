using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Models
{
    [Table("PRODUCT")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ProductId { get; set; }
        [NotNull, MaxLength(50)]
        public string ProductName { get; set; }
        [MaxLength(100)]
        public string ProductDescription { get; set; }
        public string ProductPhotoPath {  get; set; }
        [NotNull]
        public bool ProductIsConsumable {  get; set; }
        
        public int ProductAmountAlert {  get; set; } 
        //public List<ProductStock> ProductListProductStocks { get; set; }

    }
}
