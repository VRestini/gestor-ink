using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.MVVM.Models
{
    [Table("ItemProdutoUsado")]
    public class ItemProdutoUsado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public string Name { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataExclusao { get; set; }
        public string Foto { get; set; } // Caso tenha imagens associadas
    }

}
