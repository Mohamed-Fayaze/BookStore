using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class QualificationRepository : RepositoryAsync<Qualification>, IQualificationRepository
    {
        private readonly ApplicationDbContext _db;

        public QualificationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Qualification qualification)
        {

            var objFromDb = _db.Qualification.FirstOrDefault(s => s.Id == qualification.Id);
            if (objFromDb != null)
            {
                objFromDb.Description = qualification.Description;
            };
        }
    }
}
