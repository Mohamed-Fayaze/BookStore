using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Package
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string PackageName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<PackageDuration> PackageDurations { get; set; }
    }
}
