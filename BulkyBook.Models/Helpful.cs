using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Helpful
    {
        [Key]
        public int HelpfulID { get; set; }

     
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int ReviewRatingId { get; set; }

        [ForeignKey("ReviewRatingId")]
        public ReviewRating ReviewRating { get; set; }
    }
}
