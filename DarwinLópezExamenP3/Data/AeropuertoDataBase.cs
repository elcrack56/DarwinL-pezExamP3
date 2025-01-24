using SQLite;
using DarwinLópezExamenP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DarwinLópezExamenP3.Data
{
    public class AeropuertoDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public AeropuertoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DLopezAeropuerto>().Wait();  
        }

        public Task<int> GuardarAeropuertoAsync(DLopezAeropuerto aeropuerto)
        {
            return _database.InsertAsync(aeropuerto);
        }

        public Task<List<DLopezAeropuerto>> ObtenerAeropuertosAsync()
        {
            return _database.Table<DLopezAeropuerto>().ToListAsync(); 
        }
    }
}

