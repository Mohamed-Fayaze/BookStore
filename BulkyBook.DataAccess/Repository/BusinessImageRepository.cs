using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessImageRepository : RepositoryAsync<BusinessImage> , IBusinessImageRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessImageRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(BusinessImage businessImage)
        {
            var objFromDb = _db.BusinessImage.FirstOrDefault(s => s.Id == businessImage.Id);
            if (objFromDb != null)
            {
                objFromDb.Image = businessImage.Image;
            };
        }
    }
}
