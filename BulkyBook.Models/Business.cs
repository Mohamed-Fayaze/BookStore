using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Business
    {
        public int Id { get; set; }

     
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        [Display(Name ="Parent Corporation")]
        public string ParentCorporation { get; set; }
        [Display(Name = "Business Type")]
        [Required]
     
        public int? BusinessTypeId { get; set; }
        [ForeignKey("BusinessTypeId")]
        public BusinessType BusinessType { get; set; }
        [Required]
        [Display(Name = "Industry Type")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Display(Name = "Sub Category")]
        public int? SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }


        [MaxLength(200)]
        [Display(Name = "Profile Photo")]
        public string ProfilePhoto { get; set; }
        
        [Display(Name = "Year Of Registered")]
        public int YearOfRegistered { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        [Display(Name = "Verified Company")]
        public bool? IsVerified { get; set; }

        [MaxLength(30)]
        public string VerifiedStatus { get; set; }

        [MaxLength(100)]
        public string RejectedReason { get; set; }

        [MaxLength(120)]
        public string ApprovedBy { get; set; }
        [ForeignKey("ApprovedBy")]
        //public ApplicationUser ApprovedUser { get; set; }
        public DateTime ApprovedOn { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        public char LastOperation { get; set; }
        public DateTime LastOperationOn { get; set; }
    }
}
