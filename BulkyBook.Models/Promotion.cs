using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBook.Models
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [Required]
        public int? OldPrice { get; set; }
        [Required]
        public int? OfferPrice { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Please enter a value between 1 and 100")]
        public int? Discount { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public string PromoDescription { get; set; }

    }
}
