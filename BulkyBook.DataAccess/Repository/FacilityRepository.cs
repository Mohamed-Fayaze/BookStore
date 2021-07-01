using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class FacilityRepository : RepositoryAsync<Facility>, IFacilityRepository
    {
        private readonly ApplicationDbContext _db;
        public FacilityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Facility facility)
        {
            var objFromDb = _db.Facility.FirstOrDefault(s => s.Id == facility.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = facility.Name;
            };
        }
    }
}
