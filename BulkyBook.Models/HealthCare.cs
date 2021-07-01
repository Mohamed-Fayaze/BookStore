using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class HealthCare
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Category")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }
        [Display(Name = "Establishment Year")]
        public int? YearOfEstablishment { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(120)]
        [Display(Name = "Website URL")]
        public string WebsiteURL { get; set; }
        [Display(Name = "24 Hours Available")]
        public bool isFullDayAvailable { get; set; }
        [Display(Name = "From Time")]
        public TimeSpan? FromWorkingHour { get; set; }
        [Display(Name = "To Time")]
        public TimeSpan? ToWorkingHour { get; set; }
        public virtual ICollection<HealthcareBranch> HealthcareBranch { get; set; }
    }
}
