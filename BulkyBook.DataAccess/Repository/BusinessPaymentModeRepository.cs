using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessPaymentModeRepository : RepositoryAsync<BusinessPaymentMode> , IBusinessPaymentModeRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessPaymentModeRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(BusinessPaymentMode businessPaymentMode)
        {
            var objFromDb = _db.BusinessPaymentMode.FirstOrDefault(s => s.Id == businessPaymentMode.Id);
            if (objFromDb != null)
            {
                objFromDb.PaymentModeId = businessPaymentMode.PaymentModeId;
            };
        }
    }
}
