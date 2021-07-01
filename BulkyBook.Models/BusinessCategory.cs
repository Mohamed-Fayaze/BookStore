using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class BusinessCategory
    {[Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }

        [MaxLength(100)]
        public string SubCategoryId { get; set; }

        [MaxLength(100)]
        public string OtherCategoryId { get; set; }
        
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
