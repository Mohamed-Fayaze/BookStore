using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class NewAddress
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int? BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [MaxLength(10)]
        public string DoorNo { get; set; }

        //[Required(ErrorMessage = "Area is Required")]
        [MaxLength(60)]
        public string Street { get; set; }

        [MaxLength(60)]
        public string Area { get; set; }

        [MaxLength(60)]
        public string City { get; set; }

        [MaxLength(60)]
        public string State { get; set; }

        [MaxLength(60)]
        public string Country { get; set; }
        [MaxLength(200)]
        public string Website { get; set; }
        [MaxLength(200)]
        public string Latitude { get; set; }
        [MaxLength(200)]
        public string Longitude { get; set; }

    }
}
