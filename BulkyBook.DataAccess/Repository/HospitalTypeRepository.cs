using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class HospitalTypeRepository : RepositoryAsync<HospitalType>, IHospitalTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public HospitalTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(HospitalType hospitalType)
        {

            var objFromDb = _db.HospitalType.FirstOrDefault(s => s.Id == hospitalType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = hospitalType.Name;
                
            };
        }
    }
}
