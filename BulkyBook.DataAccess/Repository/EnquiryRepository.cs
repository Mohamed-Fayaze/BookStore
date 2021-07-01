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
    public class EnquiryRepository : Repository<Enquiry>, IEnquiryRepository
    {
        private readonly ApplicationDbContext _db;

        public EnquiryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Enquiry enquiry)
        {
            var objFromDb = _db.Enquiry.FirstOrDefault(s => s.UserId == enquiry.UserId);
            if (objFromDb != null)
            {
                objFromDb.Description = enquiry.Description;

            }
        }
    }
}
