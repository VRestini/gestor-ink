using AppGestorInk.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppGestorInk.Services
{
    public class SessaoService : ISessaoService
    {
        private SQLiteAsyncConnection _dbConnectionA;

        public async Task InitializeAsync()
        {
            if (_dbConnectionA == null)
            {
                await SetUpDb();
            }
        }

        private async Task SetUpDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SessaoDB.db3");
            _dbConnectionA = new SQLiteAsyncConnection(dbPath);
            await _dbConnectionA.CreateTableAsync<Sessao>();
        }

        public async Task<int> AddSessaoAsync(Sessao sessao)
        {
            await InitializeAsync();
            return await _dbConnectionA.InsertAsync(sessao);
        }

        public async Task<int> DeleteSessaoAsync(Sessao sessao)
        {
            await InitializeAsync();
            return await _dbConnectionA.DeleteAsync(sessao);
        }

        public async Task<IEnumerable<Sessao>> GetAllSessoesAsync()
        {
            await InitializeAsync();
            return await _dbConnectionA.Table<Sessao>().ToListAsync();
        }

        public async Task<IEnumerable<Sessao>> GetSessaoByDateAsync(DateTime dateTime)
        {
            await InitializeAsync();
            return await _dbConnectionA.Table<Sessao>().Where(x => x.Data.Date == dateTime.Date).ToListAsync();
        }

        public async Task<int> UpdateSessaoAsync(Sessao sessao)
        {
            await InitializeAsync();
            return await _dbConnectionA.UpdateAsync(sessao);
        }
    }
}
