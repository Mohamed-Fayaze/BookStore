using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class TechnicalService
    {
        [Key]

        public int Id { get; set; }

        public bool OnlineBooking { get; set; }

        public bool DoorService { get; set; }


        [MaxLength(200)]
        public string ServiceType { get; set; }

        public int BusinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Business { get; set; }

   
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
