using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessHourRepository : RepositoryAsync<BusinessHour> , IBusinessHourRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessHourRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(BusinessHour businessHour)
        {
            var objFromDb = _db.BusienssHour.FirstOrDefault(s => s.Id == businessHour.Id);
            if (objFromDb != null)
            {
                objFromDb.IsDualTimings = businessHour.IsDualTimings;
                objFromDb.SundayFrom = businessHour.SundayFrom;
                objFromDb.MondayFrom = businessHour.MondayFrom;
                objFromDb.TuesdayFrom = businessHour.TuesdayFrom;
                objFromDb.WednesdayFrom = businessHour.WednesdayFrom;
                objFromDb.ThrusdayFrom = businessHour.ThrusdayFrom;
                objFromDb.FridayFrom = businessHour.FridayFrom;
                objFromDb.SaturdayFrom = businessHour.SaturdayFrom;
                objFromDb.SundayFrom1 = businessHour.SundayFrom1;
                objFromDb.MondayFrom1 = businessHour.MondayFrom1;
                objFromDb.TuesdayFrom1 = businessHour.TuesdayFrom1;
                objFromDb.WednesdayFrom1 = businessHour.WednesdayFrom1;
                objFromDb.ThrusdayFrom1 = businessHour.ThrusdayFrom1;
                objFromDb.FridayFrom1 = businessHour.FridayFrom1;
                objFromDb.SaturdayFrom1 = businessHour.SaturdayFrom1;
            };
        }
    }
}
