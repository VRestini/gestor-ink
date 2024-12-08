using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestorInk.Services
{
    public class HomeService : IHomeService
    {
        private SQLiteAsyncConnection _dbConnection;
        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }
        private async Task SetUpDb()
        {
            string targetFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ImagensSessoes");
        }
        public Task<IEnumerable<string>> GetAllImageAsync()
        {
            throw new NotImplementedException();
        }

        
    }
}
