using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class BusinessImage
    {
        [Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }
       
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
