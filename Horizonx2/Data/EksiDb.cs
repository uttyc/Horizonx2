using Horizonx2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Horizonx2.Data
{
    public class EksiDb
    {
        readonly SQLiteConnection _db;

        public EksiDb(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<EksiEntry>();
        }
        //public List<EksiEntry> GetFavsAsync => _db.Table<EksiEntry>().ToList();
        public ObservableCollection<EksiEntry> GetFavsAsync() {
            
            var list = _db.Table<EksiEntry>().ToList();
            var collection = new ObservableCollection<EksiEntry>(list);
            return collection;
        }
        public EksiEntry GetFavAsync(int id)
        {
            return _db.Table<EksiEntry>()
                            .Where(i => i.Id == id)
                            .FirstOrDefault();
        }
        public int SaveFavAsync(EksiEntry entry)
        {
            if (entry.Id != 0)
            {
                return _db.Update(entry);
            }
            else
            {
                return _db.Insert(entry);
            }
        }
        public int DeleteFavAsync(EksiEntry entry)
        {
            return _db.Delete(entry);
        }
    }
}
