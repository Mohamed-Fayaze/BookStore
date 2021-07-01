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
    public class MedicalInsuranceTypeRepository : RepositoryAsync<MedicalInsuranceType>, IMedicalInsuranceTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public MedicalInsuranceTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(MedicalInsuranceType medicalInsuranceType)
        {
            var objFromDb = _db.MedicalInsuranceType.FirstOrDefault(s => s.Id == medicalInsuranceType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = medicalInsuranceType.Name;
            };
        }


    }
}
