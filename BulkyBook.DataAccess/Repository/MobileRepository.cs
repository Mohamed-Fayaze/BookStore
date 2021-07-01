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

    public class MobileRepository : RepositoryAsync<Mobile>, IMobileRepository
    {
        private readonly ApplicationDbContext _db;
        //private readonly IUnitOfWork _unitOfWork;
        public MobileRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpsertAsync(IEnumerable<Mobile> Mobiles, int AddressId)
        {
            var objFromDb = from a in _db.MobileTables where a.AddressId == AddressId select a;
            if (objFromDb != null)
            {
                _db.MobileTables.RemoveRange(objFromDb);
            }
            foreach (var item in Mobiles)
            {
                item.AddressId = AddressId;
            }
            await _db.AddRangeAsync(Mobiles);
        }
    }
}
