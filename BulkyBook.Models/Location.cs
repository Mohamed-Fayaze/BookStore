using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public int AddressId { get; set; }
        //public long RecId { get; set; }
        //[MaxLength(200)]
        //[DataType(DataType.Url)]
        //[Url]
        //public string LocationSrc { get; set; }
        [MaxLength(200)]
        public string Latitude { get; set; }
        [MaxLength(200)]
        public string Longitude { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})", ErrorMessage = "Invalid URL")]
        public string Website { get; set; }

        public virtual Address Address { get; set; }
    }
}
