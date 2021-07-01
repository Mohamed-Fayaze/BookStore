using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Mobile
    {
        [Key]
        public int MobileId { get; set; }
        public int AddressId { get; set; }
        //public int RecId { get; set; }


        //[Required(ErrorMessage ="Required,Please Enter Numbers only")]
        //[StringLength(12, MinimumLength = 10, ErrorMessage = "This is not valid Mobile Number")]

        public string MobileNo { get; set; }

        //public string MobileNo2 { get; set; }

        //public string MobileNo3 { get; set; }

        //public string MobileNo4 { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Address Address { get; set; }
    }
}
