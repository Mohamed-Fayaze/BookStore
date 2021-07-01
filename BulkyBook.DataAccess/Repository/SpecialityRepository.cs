using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class SpecialityRepository : RepositoryAsync<Speciality>, ISpecialityRepository
    {
        private readonly ApplicationDbContext _db;
        public SpecialityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Speciality speciality)
        {
            var objFromDb = _db.Speciality.FirstOrDefault(s => s.Id == speciality.Id);
            if (objFromDb != null)
            {
                objFromDb.SpecialityName = speciality.SpecialityName;
            };
        }
    }
}
