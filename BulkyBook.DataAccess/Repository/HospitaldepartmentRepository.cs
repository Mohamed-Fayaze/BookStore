using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class HospitaldepartmentRepository : RepositoryAsync<HospitalDepartment>, IHospitaldepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public HospitaldepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

   
        public void update(HospitalDepartment hospitaldepartment)
        {
            var objFromDb = _db.Hospitaldepartments.FirstOrDefault(s => s.Id == hospitaldepartment.Id);
            if (objFromDb != null)
            {
                objFromDb.DepartmentName = hospitaldepartment.DepartmentName;
            };
        }

        
    }
}
