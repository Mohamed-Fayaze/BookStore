using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class AutomobileRepository : RepositoryAsync<Automobile>, IAutomobileRepository
    {
        private readonly ApplicationDbContext _db;

        public AutomobileRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Automobile automobile)
        {

            var objFromDb = _db.Automobiles.FirstOrDefault(s => s.Id == automobile.Id);
             if (objFromDb != null)
            {
                objFromDb.Brand = automobile.Brand;
                objFromDb.Mobilemechanic = automobile.Mobilemechanic;
                objFromDb.OnlineBooking = automobile.OnlineBooking;
                objFromDb.ServiceType = automobile.ServiceType;
            };
        }
    }
}
