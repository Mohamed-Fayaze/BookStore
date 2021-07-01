using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using BulkyBook.Models;

namespace BulkyBook.Models
{
   public class ReviewRating
    {
        [Key]
        public int Id { get; set; }

        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int? BussinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business company { get; set; }
        [Required]
        public decimal OverallRating { get; set; }
        public decimal? Service { get; set; }
        public decimal? Valueformoney { get; set; }
        public decimal? OtherRating { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Please Enter character between 1 to 20")]
        public string Title { get; set; }
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Please Enter character between 1 to 200")]
        public string Description { get; set; }
        public DateTime ReviewOn { get; set; }
        public bool Recommendation { get; set; }
        public int? HelpfulCount { get; set; }
        public int OtherId { get; set; }
        [ForeignKey("OtherId")]
        public Other Other { get; set; }
       
    }
}
