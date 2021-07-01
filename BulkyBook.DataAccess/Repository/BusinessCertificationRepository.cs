using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessCertificationRepository : RepositoryAsync<BusinessCertification> , IBusinessCertificationRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessCertificationRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(BusinessCertification businessCertification)
        {
            var objFromDb = _db.BusinessCertification.FirstOrDefault(s => s.Id == businessCertification.Id);
            if (objFromDb != null)
            {
                objFromDb.Certificate = businessCertification.Certificate;
            };
        }
    }
}
