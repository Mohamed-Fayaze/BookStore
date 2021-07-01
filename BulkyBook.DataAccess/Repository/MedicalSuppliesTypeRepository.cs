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
    public class MedicalSuppliesTypeRepository : RepositoryAsync<MedicalSuppliesType>, IMedicalSuppliesTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public MedicalSuppliesTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(MedicalSuppliesType medicalSuppliesType)
        {
            var objFromDb = _db.MedicalSuppliesType.FirstOrDefault(s => s.Id == medicalSuppliesType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = medicalSuppliesType.Name;
                
            };
        }


    }
}
