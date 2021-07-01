using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class DesignationRepository : RepositoryAsync<Designation>, IDesignationRepository
    {
        private readonly ApplicationDbContext _db;

        public DesignationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Designation designation)
        {

            var objFromDb = _db.Designation.FirstOrDefault(s => s.Id == designation.Id);
            if (objFromDb != null)
            {
                objFromDb.Description = designation.Description;
            };
        }
    }
}
