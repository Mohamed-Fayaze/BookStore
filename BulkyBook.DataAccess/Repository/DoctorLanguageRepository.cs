using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class DoctorLanguageRepository : RepositoryAsync<DoctorLanguage> , IDoctorLanguageRepository
    {
        private readonly ApplicationDbContext _db;
        public DoctorLanguageRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(DoctorLanguage doctorLanguage)
        {
            //var objFromDb = _db.DoctorLanguage.FirstOrDefault(s => s.Id == doctorLanguage.Id);
            //if (objFromDb != null)
            //{
            //    objFromDb.Description = doctorLanguage.Description;
            //};
        }
    }
}
