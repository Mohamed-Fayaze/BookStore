using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessTypeRepository : RepositoryAsync<BusinessType>, IBusinessTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BusinessType businessType)
        {
            var objFromDb = _db.BusinessType.FirstOrDefault(s => s.Id == businessType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = businessType.Name;
            };
        }
    }
}
