using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Preference
    {
        [Key]
        public int Id { get; set; }

     
        public string UserId { get; set; }
        [Display(Name = "Nationality")]
        [MaxLength(100)]
        public string Language { get; set; }

        [MaxLength(100)]
        public string Industry { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
