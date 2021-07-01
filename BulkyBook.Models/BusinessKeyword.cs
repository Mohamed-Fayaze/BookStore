using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class BusinessKeyword
    {
        [Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
     
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
