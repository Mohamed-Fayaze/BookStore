using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessServiceRepository : RepositoryAsync<BusinessService> , IBusinessServiceRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessServiceRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(BusinessService businessService)
        {
            var objFromDb = _db.BusinessService.FirstOrDefault(s => s.Id == businessService.Id);
            if (objFromDb != null)
            {
                objFromDb.ServicesId = businessService.ServicesId;
            };
        }
    }
}
