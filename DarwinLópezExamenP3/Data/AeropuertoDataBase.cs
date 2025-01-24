
using DarwinLópezExamenP3.Models;
using SQLite;

namespace DarwinLópezExamenP3.Data
{
    public class AeropuertoDataBase
    {
        private readonly SQLiteAsyncConnection _database;

        public AeropuertoDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DLopezAeropuerto>().Wait();
        }

        public Task<int> SaveAeropuertoAsync(DLopezAeropuerto aeropuerto)
        {
            return _database.InsertAsync(aeropuerto);
        }

        public Task<List<DLopezAeropuerto>> GetAeropuertosAsync()
        {
            return _database.Table<DLopezAeropuerto>().ToListAsync();
        }
    }
}

