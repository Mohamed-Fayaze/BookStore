using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
     public class PromotionVM
    {
        public Promotion Promotion { get; set; }
        public IEnumerable<Promotion> Promotions { get; set; }
        public Promotionimage Promotionimage { get; set; }
        public IEnumerable<Promotionimage> Promotionimages { get; set; }
        public IEnumerable<SelectListItem> BusinessList { get; set; }
    }
}
