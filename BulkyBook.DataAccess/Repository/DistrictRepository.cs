using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class DistrictRepository : RepositoryAsync<District>, IDistrictRepository
    {
        private readonly ApplicationDbContext _db;

        public DistrictRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(District district)
        {

            var objFromDb = _db.District.FirstOrDefault(s => s.Id == district.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = district.Name;
            };
        }
    }
}
