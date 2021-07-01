using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IServicesRepository : IRepositoryAsync<Services>
    {
        void Update(Services service);
    }
}
