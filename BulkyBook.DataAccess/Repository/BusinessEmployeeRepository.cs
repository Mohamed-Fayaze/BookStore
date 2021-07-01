using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessEmployeeRepository : RepositoryAsync<BusinessEmployee>, IBusinessEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public BusinessEmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BusinessEmployee businessEmployee)
        {

            var objFromDb = _db.BusinessEmployee.FirstOrDefault(s => s.Id == businessEmployee.Id);
            if (objFromDb != null)
            {
                if (businessEmployee.PhotoUrl != null)
                {
                    objFromDb.PhotoUrl = businessEmployee.PhotoUrl;
                }
                objFromDb.Experience = businessEmployee.Experience;
                objFromDb.Name = businessEmployee.Name;
                objFromDb.Nationality = businessEmployee.Nationality;
                
            };
        }
    }
}
