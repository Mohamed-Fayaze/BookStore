using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class RestaurantMenu
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(130)]
        public String Name { get; set; }


        [MaxLength(200)]
        public string ImagePath { get; set; }

        public int RestaurantId { get; set; }

        public int BusinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Company { get; set; }


    }
}
