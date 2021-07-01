using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ITechnicalServiceRepository : IRepositoryAsync<TechnicalService>
    {
        void Update(TechnicalService technicalService);
    }
}
