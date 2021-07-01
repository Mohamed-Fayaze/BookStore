using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class PromotionimageRepository : RepositoryAsync<Promotionimage>, IPromotionimageRepository
    {
        private readonly ApplicationDbContext _db;
        public PromotionimageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Promotionimage promotionimage)
        {
            var objFromDb = _db.Promotionimage.FirstOrDefault(s => s.Id == promotionimage.Id);
            if (objFromDb != null)
            {
                objFromDb.Images = promotionimage.Images;
            };

        }
    }
}
