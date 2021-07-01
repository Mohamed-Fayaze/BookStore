using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IDesignationRepository : IRepositoryAsync<Designation>
    {
        void Update(Designation designation);
    }
}
