using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.MVVM.Models
{
    public class JwtResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime Expiration { get; set; }
    }
}
