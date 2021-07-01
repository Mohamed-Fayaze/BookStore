using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ReportasinaccurateRepository : Repository<Reportasinaccurate>,IReportasinaccurateRepository
    {
        private readonly ApplicationDbContext _db;

        public ReportasinaccurateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Reportasinaccurate reportasinaccurate)
        {
            var objFromDb = _db.Reportasinaccurates.FirstOrDefault(s => s.UserId == reportasinaccurate.UserId);
            if (objFromDb != null)
            {
                objFromDb.Description = reportasinaccurate.Description;

            }
        }
    }
}
