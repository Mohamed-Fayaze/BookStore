using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class NationalityRepository : RepositoryAsync<Nationality>, INationalityRepository
    {
        private readonly ApplicationDbContext _db;

        public NationalityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Nationality nationality)
        {

            var objFromDb = _db.Nationality.FirstOrDefault(s => s.Id == nationality.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = nationality.Name;
            };
        }
    }
}
