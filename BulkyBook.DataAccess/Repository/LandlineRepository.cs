using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    class LandlineRepository : RepositoryAsync<Landline>, ILandlineRepository
    {
        private readonly ApplicationDbContext _db;
        public LandlineRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpsertAsync(IEnumerable<Landline> Landlines, int AddressId)
        {
            var objFromDb = from a in _db.LandlineTables where a.AddressId == AddressId select a;
            if (objFromDb != null)
            {
                _db.LandlineTables.RemoveRange(objFromDb);
            }
            foreach (var item in Landlines)
            {
                item.AddressId = AddressId;
            }
            await _db.AddRangeAsync(Landlines);
        }
    }
}
