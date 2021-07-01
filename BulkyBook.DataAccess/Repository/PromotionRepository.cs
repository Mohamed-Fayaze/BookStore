using BulkyBook.DataAccess.Data;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
   public class PromotionRepository : Repository<Promotion>,IPromotionRepository
    {
        private readonly ApplicationDbContext _db;

        public PromotionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Promotion promotion)
        {
            var objFromDb = _db.Promotions.FirstOrDefault(s => s.Id == promotion.Id);
            if (objFromDb != null)
            {
                //objFromDb.BusinessId = promotion.BusinessId;
                //objFromDb.BusinessName = promotion.BusinessName;
                objFromDb.OldPrice = promotion.OldPrice;
                objFromDb.OfferPrice = promotion.OfferPrice;
                objFromDb.Discount = promotion.Discount;
                objFromDb.StartDate = promotion.StartDate;
                objFromDb.EndDate = promotion.EndDate;
                objFromDb.PromoDescription = promotion.PromoDescription;
               


            }
        }
         
    }
}
