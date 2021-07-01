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
    public class IndustryTypeRepository : RepositoryAsync<IndustryType>, IIndustryTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public IndustryTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(IndustryType industryType)
        {
            var objFromDb = _db.IndustryTypes.FirstOrDefault(s => s.Id == industryType.Id);
            if (objFromDb != null)
            {
                objFromDb.IndustryTypeName = industryType.IndustryTypeName;
            };
        }

        
    }
}
