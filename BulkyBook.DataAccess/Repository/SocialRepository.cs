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
    class SocialRepository : RepositoryAsync<Social>, ISocialRepository
    {
        private readonly ApplicationDbContext _db;
        public SocialRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpsertAsync(IEnumerable<Social> socials, int AddressId)
        {
            var objFromDb = from a in _db.SocialTables where a.AddressId == AddressId select a;
            if (objFromDb != null)
            {
                _db.SocialTables.RemoveRange(objFromDb);
            }
            foreach (var item in socials)
            {
                item.AddressId = AddressId;
            }
            await _db.AddRangeAsync(socials);
        }
    }
}
