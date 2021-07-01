using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class OtherRepository : Repository<Other>,IOtherRepository
    {
        private readonly ApplicationDbContext _db;

        public OtherRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Other other)
        {
            var objFromDb = _db.Others.FirstOrDefault(s => s.Id == other.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = other.Name;
               
            }
        }
    }
}
