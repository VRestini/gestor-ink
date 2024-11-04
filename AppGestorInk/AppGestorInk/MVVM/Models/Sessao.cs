using SQLite;

using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestorInk.MVVM.Models
{
    [SQLite.Table("Sessao")]
    public class Sessao
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }

        [NotNull, MaxLength(40)]
        public string NomeSessao { get; set; }
        [NotNull, MaxLength(40)]
        public string NomeCliente { get; set; }
        [NotNull, MaxLength(100)]
        public string Descricao {  get; set; }
        
        [NotNull] 
        public DateTime Data { get; set; }

        public enum StatusSessao
        {
            Finalizada,
            Processo,
        };
    }
}
