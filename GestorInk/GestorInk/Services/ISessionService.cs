using GestorInk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Services
{
    public interface ISessionService
    {
        Task Init();
        Task<IEnumerable<Session>> GetSessionBydate();        
        Task CreateSession(Session session);
        Task RefreshSession(Session session);

        Task DeleteSession(Session session);
    }
}
