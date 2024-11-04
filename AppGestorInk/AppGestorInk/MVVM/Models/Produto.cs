using SQLite;
using System.Collections.ObjectModel;

namespace AppGestorInk.MVVM.Models
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, MaxLength(30)]
        public string Name { get; set; }

        [NotNull, MaxLength(60)]
        public string Descricao { get; set; }
        
        [Ignore]
        public ObservableCollection<ItemProduto> ItemProdutos { get; set; } = new ObservableCollection<ItemProduto>();
    }
}
