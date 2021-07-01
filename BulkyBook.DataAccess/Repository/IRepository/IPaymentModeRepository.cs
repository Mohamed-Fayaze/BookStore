using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IPaymentModeRepository : IRepositoryAsync<PaymentMode>
    {
        void Update(PaymentMode paymentMode);
    }
}
