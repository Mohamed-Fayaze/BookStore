using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Restaurant
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(200)]
        public string Features { get; set; }

        [MaxLength(200)]
        public string Cuisines { get; set; }

        [MaxLength(200)]
        public string Meals { get; set; }

        public bool OnlineBooking { get; set; }

        public bool DoorDelivery { get; set; }

        [MaxLength(200)]
        public string Amenities { get; set; }

        [MaxLength(200)]
        public string Dishes { get; set; }

        [MaxLength(200)]
        public string DietaryRestrictions { get; set; }

        public int miniprice { get; set; }
        public int maxprice { get; set; }

        [MaxLength(200)] 
        public string GoodFor { get; set; }

        [MaxLength(200)]
        public string  Paymentmode { get; set; }


        [MaxLength(200)]
        public string Menu { get; set; }

        [MaxLength(200)]
        public string Gallery { get; set; }

        [MaxLength(200)]
        public string standard { get; set; }

        public int BusinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Business { get; set; }

    
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
