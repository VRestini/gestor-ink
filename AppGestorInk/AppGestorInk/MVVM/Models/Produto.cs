using SQLite;

namespace AppGestorInk.MVVM.Models
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, MaxLength(30)]
        public string Name { get; set; }

        [NotNull, MaxLength(50)]
        public string Descricao { get; set; }
    }
}
