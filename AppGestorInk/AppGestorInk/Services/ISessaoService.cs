using AppGestorInk.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.Services
{
    public interface ISessaoService
    {
        Task InitializeAsync();
        Task <IEnumerable<Sessao>> GetAllSessoesAsync();
        Task <IEnumerable<Sessao>> GetSessaoByDateAsync(DateTime dateTime);
        Task <int> AddSessaoAsync(Sessao sessao);
        Task <int> DeleteSessaoAsync(Sessao sessao);
        Task <int> UpdateSessaoAsync(Sessao sessao);
    }
}
