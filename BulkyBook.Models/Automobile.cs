using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Automobile
    {
        [Key]

        public int Id { get; set; }

        public bool OnlineBooking { get; set; }

        [MaxLength(150)]
        public string Brand { get; set; }

        [MaxLength(200)]
        public string ServiceType { get; set; }
      

        public bool Mobilemechanic { get; set; }

        public int BusinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Company { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
