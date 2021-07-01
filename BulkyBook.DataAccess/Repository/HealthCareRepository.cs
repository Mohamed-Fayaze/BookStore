using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class HealthCareRepository : RepositoryAsync<HealthCare>, IHealthCareRepository
    {
        private readonly ApplicationDbContext _db;
        public HealthCareRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(HealthCare healthCare)
        {
            var objFromDb = _db.HealthCare.FirstOrDefault(s => s.Id == healthCare.Id);
            if (objFromDb != null)
            {
                objFromDb.Description = healthCare.Description;
                objFromDb.SubCategoryId = healthCare.SubCategoryId;
                objFromDb.FromWorkingHour = healthCare.FromWorkingHour;
                objFromDb.isFullDayAvailable = healthCare.isFullDayAvailable;
                objFromDb.Name = healthCare.Name;
                objFromDb.ToWorkingHour = healthCare.ToWorkingHour;
                objFromDb.WebsiteURL = healthCare.WebsiteURL;
                objFromDb.YearOfEstablishment = healthCare.YearOfEstablishment;
            }
        }
        public IEnumerable<HealthCare> GetAllHealthcare()
        {
            //var query = _db.HealthcareBranch.Include(i => i.Healthcare).ToList().GroupBy(g => g.Healthcare.Id).SelectMany(s => s);
            var query = from a in _db.HealthCare.Include(s => s.HealthcareBranch) select a;
            return query;
        }

    }
}
