using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class PaymentModeRepository : RepositoryAsync<PaymentMode> , IPaymentModeRepository
    {
        private readonly ApplicationDbContext _db;
        public PaymentModeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(PaymentMode paymentMode)
        {
            var objFromDb = _db.PaymentMode.FirstOrDefault(s => s.Id == paymentMode.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = paymentMode.Name;
            };
        }
    }
}
