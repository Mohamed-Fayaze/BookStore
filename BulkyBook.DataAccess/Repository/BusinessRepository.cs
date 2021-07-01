using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessRepository : RepositoryAsync<Business> , IBusinessRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Business business)
        {
            var objFromDb = _db.Business.FirstOrDefault(s => s.Id == business.Id);
            if (objFromDb != null)
            {
                objFromDb.ProfilePhoto = business.ProfilePhoto;
                objFromDb.Description = business.Description;
                objFromDb.IsVerified = business.IsVerified;
                objFromDb.VerifiedStatus = business.VerifiedStatus;
                objFromDb.RejectedReason = business.RejectedReason;
                objFromDb.ApprovedBy = business.ApprovedBy;
                objFromDb.ApprovedOn = business.ApprovedOn;
                objFromDb.LastOperation = business.LastOperation;
                objFromDb.LastOperationOn = business.LastOperationOn;
            };
        }
    }
}
