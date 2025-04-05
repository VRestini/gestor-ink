using GestorInk.Data;
using GestorInk.Models;
using GestorInk.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInk.Repositorys
{
    public class SessionRepository: ISessionService
    {
        private SQLiteAsyncConnection _dbconnection;
        public async Task Init()
        {
            if (_dbconnection != null)
                return;
            _dbconnection = new SQLiteAsyncConnection(ConstantsDB.DatabasePath, ConstantsDB.Flags);
            await _dbconnection.CreateTableAsync<Session>();
            System.Diagnostics.Debug.WriteLine("Database of session was initialized successfully.");

        }
        public async Task CreateSession(Session session)
        {
            
        }

        public async Task DeleteSession(Session session)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Session>> GetSessionBydate()
        {
            throw new NotImplementedException();
            
        }       
        public async Task RefreshSession(Session session)
        {
            throw new NotImplementedException();
        }
    }
}
