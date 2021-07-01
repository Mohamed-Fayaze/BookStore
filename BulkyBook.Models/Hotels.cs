using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Hotels
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(200)]
        public string Type { get; set; }

        [MaxLength(100)]
        public string Minprice { get; set; }

        [MaxLength(200)]
        public string Paymentmode { get; set; }

        public bool OnlineBooking { get; set; }

        public int  Hotelclass { get; set; }

        [MaxLength(100)]
        public string style { get; set; }

        [MaxLength(200)]
        public string Amenities { get; set; }


        public int BusinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Business { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
