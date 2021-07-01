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
    public class TestingLabTypeRepository : RepositoryAsync<TestingLabType>, ITestingLabTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public TestingLabTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(TestingLabType testingLabType)
        {
            var objFromDb = _db.TestingLabType.FirstOrDefault(s => s.Id == testingLabType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = testingLabType.Name;

            };
        }


    }
}
