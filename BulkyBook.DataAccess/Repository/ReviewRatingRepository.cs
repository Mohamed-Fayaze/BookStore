using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ReviewRatingRepository : Repository<ReviewRating>, IReviewRatingRepository
    {
        private readonly ApplicationDbContext _db;

        public ReviewRatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ReviewRating reviewRating)
        {
            var objFromDb = _db.ReviewRatings.Where(s => s.Id == reviewRating.Id).FirstOrDefault();
            if (objFromDb != null)
            {
                if (reviewRating.Image != null)
                {
                    objFromDb.Image = reviewRating.Image;
                }
                objFromDb.OverallRating = reviewRating.OverallRating;
                objFromDb.Service = reviewRating.Service;
                objFromDb.Valueformoney = reviewRating.Valueformoney;
                objFromDb.OtherRating = reviewRating.OtherRating;
                objFromDb.Title = reviewRating.Title;
                objFromDb.Description = reviewRating.Description;
                objFromDb.OtherId = reviewRating.OtherId;
                objFromDb.Recommendation = reviewRating.Recommendation;

                
            }
        }
        public int Rowcount()
        {
            return (from row in _db.ReviewRatings select row).Count();
        }
        public bool ValidateHelpful(string userId, int reviewratingId)
        {
            return _db.Helpfuls.Where(x => x.UserId == userId && x.ReviewRatingId == reviewratingId).Any();
        }
        public bool ValidateReportAbuse(string userId, int reviewratingId)
        {
            return _db.ReportAbuses.Where(x => x.UserId == userId && x.ReviewRatingId == reviewratingId).Any();
        }
        public decimal GetAverageRating(int businessid)
        {
            var review = _db.ReviewRatings.Where(x => x.BussinessId == businessid && x.OverallRating > 0).ToList();
            decimal average = review.Sum(s => s.OverallRating);
            if (review.Count == 0)
            {
                return 0;
            }
            else
            {
                var result = average / review.Count ;
                return (Math.Round(result, 1));
            }
        }
    }
}
