using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Models
{
    [Table("USER")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        private int IdUser { get; set; }
        [NotNull]
        private string UserName { get; set; }
        [NotNull]
        private int UserAge { get; set; }
        [NotNull]
        private string UserEmail { get; set; }
        [NotNull]
        private string UserPassword {  get; set; }
        [NotNull]
        private string UserPhotoPath { get; set; }
    }
}
