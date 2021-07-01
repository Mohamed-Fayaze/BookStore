using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class TechnicalServiceRepository : RepositoryAsync<TechnicalService>, ITechnicalServiceRepository
    {
        private readonly ApplicationDbContext _db;

        public TechnicalServiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TechnicalService technicalService)
        {

            var objFromDb = _db.TechnicalServices.FirstOrDefault(s => s.Id == technicalService.Id);
            if (objFromDb != null)
            {
                objFromDb.DoorService = technicalService.DoorService;
                objFromDb.OnlineBooking = technicalService.OnlineBooking;
                objFromDb.ServiceType = technicalService.ServiceType;
            };
        }
    }
}
