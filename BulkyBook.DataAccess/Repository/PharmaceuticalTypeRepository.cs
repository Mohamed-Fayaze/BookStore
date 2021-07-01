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
    public class PharmaceuticalTypeRepository : RepositoryAsync<PharmaceuticalType>, IPharmaceuticalTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public PharmaceuticalTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(PharmaceuticalType pharmaceuticalType)
        {
            var objFromDb = _db.PharmaceuticalType.FirstOrDefault(s => s.Id == pharmaceuticalType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = pharmaceuticalType.Name;

            };
        }


    }
}
