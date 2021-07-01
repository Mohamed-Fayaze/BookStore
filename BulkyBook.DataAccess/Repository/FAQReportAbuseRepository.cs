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
    public class FAQReportAbuseRepository : Repository<FAQReportAbuse>,IFAQReportAbuseRepository
    {
        private readonly ApplicationDbContext _db;

        public FAQReportAbuseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Update(Helpful helpful)
        //{
        //    var objFromDb = _db.Helpfuls.FirstOrDefault(s => s.HelpfulID == helpful.HelpfulID);
        //    if (objFromDb != null)
        //    {
        //        objFromDb.ReviewRatingId = helpful.ReviewRatingId;
               
        //    }
        //}
    }
}
