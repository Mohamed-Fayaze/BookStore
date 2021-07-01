using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Landline
    {
        [Key]
        public int LandlineId { get; set; }
        public int AddressId { get; set; }
        //public long RecId { get; set; }
        [MaxLength(14)]

        //[Required(ErrorMessage = "Required,Please Enter Numbers only")]
        //[StringLength(12, MinimumLength = 10, ErrorMessage = "This is not valid Landline Number")]
        public string LandlineNo { get; set; }
        public bool Isprimary { get; set; }

        public virtual Address Address { get; set; }
    }
}
