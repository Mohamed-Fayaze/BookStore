using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessKeywordRepository : RepositoryAsync<BusinessKeyword> , IBusinessKeywordRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessKeywordRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(BusinessKeyword businessKeyword)
        {
            var objFromDb = _db.BusinessKeyword.FirstOrDefault(s => s.Id == businessKeyword.Id);
            if (objFromDb != null)
            {
                objFromDb.Description = businessKeyword.Description;
            };
        }
    }
}
