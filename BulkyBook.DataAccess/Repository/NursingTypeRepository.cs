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
    public class NursingTypeRepository : RepositoryAsync<NursingType>, INursingTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public NursingTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(NursingType nursingType)
        {
            var objFromDb = _db.NursingType.FirstOrDefault(s => s.Id == nursingType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name =nursingType.Name;

            };
        }


    }
}
