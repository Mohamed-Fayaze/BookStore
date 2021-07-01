using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class HotelsRepository : RepositoryAsync<Hotels>, IHotelsRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Hotels hotels)
        {

            var objFromDb = _db.Hotels.FirstOrDefault(s => s.Id == hotels.Id);
            if (objFromDb != null)
            {
                objFromDb.Amenities = hotels.Amenities;
                objFromDb.Hotelclass = hotels.Hotelclass;
                objFromDb.OnlineBooking = hotels.OnlineBooking;
                objFromDb.Minprice = hotels.Minprice;
                objFromDb.Paymentmode = hotels.Paymentmode;
                objFromDb.style = hotels.style;
                objFromDb.Type = hotels.Type;
            };
        }
    }
}
