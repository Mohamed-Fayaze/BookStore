using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [Required]  
        [Display(Name ="First Name")]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Display(Name = "Profile")]
        [MaxLength(200)]
        public string ProfilePhoto { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Business Company { get; set; }
        public bool? IsVerified { get; set; }

        [MaxLength(30)]
        public string VerifiedStatus { get; set; }

        [MaxLength(100)]
        public string RejectedReason { get; set; }

        [MaxLength(200)]
        public string ApprovedBy { get; set; }
        //[ForeignKey("ApprovedBy")]
        ////public ApplicationUser ApprovedUser { get; set; }
        public DateTime ApprovedOn { get; set; }
        [NotMapped]

        [MaxLength(100)]
        public string Role { get; set; }
    }
}
