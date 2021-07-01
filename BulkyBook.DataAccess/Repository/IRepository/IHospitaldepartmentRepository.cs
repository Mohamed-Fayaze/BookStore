using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IHospitaldepartmentRepository:IRepositoryAsync<HospitalDepartment>
    {
        void update(HospitalDepartment hospitaldepartment);
    }
}
