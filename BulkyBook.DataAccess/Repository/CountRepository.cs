using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class CountRepository : RepositoryAsync<Count>, ICountRepository
    {
        private readonly ApplicationDbContext _db;

        public CountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Count count)
        {

            var objFromDb = _db.Count.FirstOrDefault(s => s.Id == count.Id);
            if (objFromDb != null)
            {
                objFromDb.viewcount = count.viewcount;
            };
        }
       
    }
}
