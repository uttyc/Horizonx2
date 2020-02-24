using Horizonx2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horizonx2.Data
{
    class EksiDb
    {
        readonly SQLiteAsyncConnection _db;

        public EksiDb(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<EksiEntry>().Wait();
        }
        public Task<List<EksiEntry>> GetFavsAsync => _db.Table<EksiEntry>().ToListAsync();
        public Task<EksiEntry> GetFavAsync(int id)
        {
            return _db.Table<EksiEntry>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveFavAsync(EksiEntry entry)
        {
            if (entry.Id != 0)
            {
                return _db.UpdateAsync(entry);
            }
            else
            {
                return _db.InsertAsync(entry);
            }
        }
        public Task<int> DeleteFavAsync(EksiEntry entry)
        {
            return _db.DeleteAsync(entry);
        }
    }
}
