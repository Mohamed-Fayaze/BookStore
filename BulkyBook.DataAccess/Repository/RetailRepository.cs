using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class RetailRepository : RepositoryAsync<Retail>, IRetailRepository
    {
        private readonly ApplicationDbContext _db;

        public RetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Retail retail)
        {

            var objFromDb = _db.Retails.FirstOrDefault(s => s.Id == retail.Id);
            if (objFromDb != null)
            {
                objFromDb.DoorDelivery = retail.DoorDelivery;
                objFromDb.minorder = retail.minorder;
                objFromDb.OnlineBooking = retail.OnlineBooking;
                objFromDb.RetailType = retail.RetailType;
            };
        }
    }
}
