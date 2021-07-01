using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IEmployeeTypeRepository : IRepositoryAsync<EmployeeType>
    {
        void Update(EmployeeType employeeType);
    }

}
