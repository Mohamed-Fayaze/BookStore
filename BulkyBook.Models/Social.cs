using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Social
    {
        [Key]
        public int SocialId { get; set; }
        public int AddressId { get; set; }
        //public long RecId { get; set; }
        //[Required]
        //[StringLength(60, MinimumLength = 3, ErrorMessage = "Please Enter Valid SocialType Ex(Facebook,Twitter)")]
        public string SocialType { get; set; }
        //[Required]
        //[MaxLength(120)]
        //[DataType(DataType.Url)]
        public string SocialLink { get; set; }

        public virtual Address Address { get; set; }
    }
}
