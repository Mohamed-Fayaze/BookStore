using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class EmployeeTypeRepository : RepositoryAsync<EmployeeType>, IEmployeeTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmployeeType employeeType)
        {

            var objFromDb = _db.EmployeeType.FirstOrDefault(s => s.Id == employeeType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = employeeType.Name;
            };
        }
    }
}
