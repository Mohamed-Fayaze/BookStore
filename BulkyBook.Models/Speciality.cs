using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Speciality
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string SpecialityName { get; set; }

    }
}
