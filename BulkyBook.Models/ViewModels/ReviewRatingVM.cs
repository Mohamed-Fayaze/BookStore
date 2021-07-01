
using System;
using System.Collections.Generic;
using System.Text;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Models.ViewModels
{
    public class ReviewRatingVM
    {
        public ReviewRating ReviewRating { get; set; }
        public IEnumerable<ReviewRating> ReviewRatings { get; set; }
        //public IEnumerable<SelectListItem> OtherList { get; set; }
        public Other Other { get; set; }
        public IEnumerable<Helpful> Helpful { get; set; }
        public IEnumerable<ReportAbuse> ReportAbuse { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
