using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Event
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(200)]
        public string Offer { get; set; }

        public int Totalmembers { get; set; }

        [MaxLength(200)]
        public string OrganizerName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime Timing { get; set; }

        public int Fees { get; set; }

        [MaxLength(200)]
        public string Type { get; set; }

        [MaxLength(200)]
        public string SubType { get; set; }

        public bool OnlineBooking { get; set; }

        [MaxLength(200)]
        public string Paymentmode { get; set; }

        public int BusinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Business { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
