using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IAddressRepository : IRepositoryAsync<Address>
    {
        void Update(Address addressTable);
    }

}
