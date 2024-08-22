using SQLite;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.MVVM.Models
{
    [Table( "Item")]
    public class ItemProduto 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public double Preco { get; set; }
        [NotNull]
        public int Quantidade { get; set; }
    }
}
