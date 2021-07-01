using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ServicesRepository : RepositoryAsync<Services> , IServicesRepository
    {
        private readonly ApplicationDbContext _db;
        public ServicesRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Services services)
        {
            var objFromDb = _db.Service.FirstOrDefault(s => s.Id == services.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = services.Name;
            };
        }
    }
}
