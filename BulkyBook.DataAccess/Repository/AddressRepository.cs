using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    class AddressRepository : RepositoryAsync<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _db;
        public AddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Address addressTable)
        {
            var objFromDb = _db.AddressTables.FirstOrDefault(s => s.AddressId == addressTable.AddressId);
            if (objFromDb != null)
            {
                objFromDb.HouseNo = addressTable.HouseNo;
                objFromDb.AddressField = addressTable.AddressField;
                objFromDb.AreaStreet = addressTable.AreaStreet;
                objFromDb.CityTown = addressTable.CityTown;
                objFromDb.StateProvinceRegion = addressTable.StateProvinceRegion;
                objFromDb.Country = addressTable.Country;
                objFromDb.Pincode = addressTable.Pincode;
                objFromDb.Landmark = addressTable.Landmark;
                objFromDb.AddressType = addressTable.AddressType;
                objFromDb.IsPrimary = addressTable.IsPrimary;
            };
        }
    }
}
