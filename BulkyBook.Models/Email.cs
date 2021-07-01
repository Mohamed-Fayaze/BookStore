using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Email
    {
        [Key]
        public int EmailAddressId { get; set; }
        public int AddressId { get; set; }
        //public int RecId { get; set; }



        //[MaxLength(60)]
        //[EmailAddress(ErrorMessage ="Not a Valid Email")]

        public string EmailAddress { get; set; }

        //[DataType(DataType.Url)]

        public bool IsPrimary { get; set; }

        public virtual Address Address { get; set; }
    }
}
