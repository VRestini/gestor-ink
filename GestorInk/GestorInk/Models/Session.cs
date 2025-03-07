using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Models
{
    [Table("SESSION")]
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int SessionId { get; set; }

        [NotNull, MaxLength(40)]
        public string SessionName { get; set; }
        [NotNull, MaxLength(40)]
        public string ClientName { get; set; }
        [ MaxLength(100)]
        public string SessionDescription { get; set; }

        [NotNull]
        public DateTime ScheduledDate { get; set; }
        [NotNull]
        public string SessionPhoto { get; set; }
        [NotNull]
        public SessionStatus sessionStatus { get; set; }

    }
}
