using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IPharmaceuticalTypeRepository : IRepositoryAsync<PharmaceuticalType>
    {
        void update(PharmaceuticalType pharmaceuticalType);
    }
}
