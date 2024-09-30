using AppGestorInk.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.Services
{
    public class SessaoService : ISessaoService
    {
        private SQLiteAsyncConnection _dbConnectionA;
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb() // configura o serviço sqlite
        {
            if (_dbConnectionA == null) // se nn existir conexão ele cria, juntamente da tabela
            {
                string dbPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SessaoDB.db3"); // definir caminho

                _dbConnectionA = new SQLiteAsyncConnection(dbPath);
                await _dbConnectionA.CreateTableAsync<Sessao>();
                
            }
        }
        public async Task<int> AddSessaoAsync(Sessao sessao)
        {
            return await _dbConnectionA.InsertAsync(sessao);
        }

        public async Task<int> DeleteSessaoAsync(Sessao sessao)
        {
            return await _dbConnectionA.DeleteAsync(sessao);
            
        }

        public async Task<IEnumerable<Sessao>> GetAllSessoesAsync()
        {
            
            var sessoes = await _dbConnectionA.Table<Sessao>().ToListAsync();
            return sessoes;
        }

        public async Task<IEnumerable< Sessao>> GetSessaoByDateAsync(DateTime dateTime)
        {
            var sessoes = await _dbConnectionA.Table<Sessao>().Where(x => x.Data.Equals(dateTime)).ToListAsync();
            return sessoes;
        }

        public Task<int> UpdateSessaoAsync(Sessao sessao)
        {
            return _dbConnectionA.UpdateAsync(sessao);
        }
    }
}
