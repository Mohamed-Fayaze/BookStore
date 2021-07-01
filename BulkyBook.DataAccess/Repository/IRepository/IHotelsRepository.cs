using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IHotelsRepository : IRepositoryAsync<Hotels>
    {
        void Update(Hotels hotels);
    }
}
