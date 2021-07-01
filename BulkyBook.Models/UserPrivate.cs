using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class UserPrivate
    {
        [Key]
        public int Id { get; set; }
      
        public string UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Marital Status")]
        [MaxLength(50)]
        public string MaritalStatus { get; set; }

        [MaxLength(100)]
        public string Occupation { get; set; }
        [Display(Name = "School")]
        [MaxLength(200)]
        public string SchoolName { get; set; }
        [Display(Name = "College")]
        [MaxLength(200)]
        public string CollegeName { get; set; }
        [Display(Name = "Company Name")]
        [MaxLength(200)]
        public string CompanyName { get; set; }
        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(300)]
        public string About { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
