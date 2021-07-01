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
    class LocationRepository : RepositoryAsync<Location>, ILocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Location locationTable)
        {
            var objFromDb = _db.LocationTables.FirstOrDefault(s => s.AddressId == locationTable.AddressId);
            if (objFromDb != null)
            {
                objFromDb.Website = locationTable.Website;
                objFromDb.Latitude = locationTable.Latitude;
                objFromDb.Longitude = locationTable.Longitude;
            };
        }
    }
}
