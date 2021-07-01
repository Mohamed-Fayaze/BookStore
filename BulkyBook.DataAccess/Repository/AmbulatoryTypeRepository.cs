using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class AmbulatoryTypeRepository : RepositoryAsync<AmbulatoryType>, IAmbulatoryTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public AmbulatoryTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AmbulatoryType ambulatoryType)
        {

            var objFromDb = _db.AmbulatoryType.FirstOrDefault(s => s.Id == ambulatoryType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = ambulatoryType.Name;
            };
        }
    }
}
