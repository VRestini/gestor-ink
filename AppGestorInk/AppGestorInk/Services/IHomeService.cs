using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.Services
{
    public interface IHomeService
    {
        Task InitializeAsync();
        Task<IEnumerable<string>> GetAllImageAsync();
    }
}
