using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Fitness
    {
        [Key]

        public int Id { get; set; }

        public int minprice { get; set; }

        public bool Gender { get; set; }

        [MaxLength(100)]
        public string Mode { get; set; }

        public string FitnessType { get; set; }

        public bool Traineravailable { get; set; }

        public bool OnlineBooking { get; set; }

        public int BusinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Business { get; set; }

      
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
