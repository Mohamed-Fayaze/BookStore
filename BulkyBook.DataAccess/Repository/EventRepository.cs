using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class EventRepository : RepositoryAsync<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Event events)
        {

            var objFromDb = _db.Events.FirstOrDefault(s => s.Id == events.Id);
            if (objFromDb != null)
            {
                objFromDb.Description = events.Description;
                objFromDb.Fees = events.Fees;
                objFromDb.Offer = events.Offer;
                objFromDb.OnlineBooking = events.OnlineBooking;
                objFromDb.OrganizerName = events.OrganizerName;
                objFromDb.Paymentmode = events.Paymentmode;
                objFromDb.SubType = events.SubType;
                objFromDb.Timing = events.Timing;
                objFromDb.Totalmembers = events.Totalmembers;
                objFromDb.Type = events.Type;
            };
        }
    }
}
