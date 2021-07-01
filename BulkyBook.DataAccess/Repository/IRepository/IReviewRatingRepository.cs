using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IReviewRatingRepository : IRepository<ReviewRating>
    {
        void Update(ReviewRating reviewRating);
        int Rowcount();
        bool ValidateHelpful(string userId, int reviewratingId);
        bool ValidateReportAbuse(string userId, int reviewratingId);
        decimal GetAverageRating(int businessid);
    }
}
