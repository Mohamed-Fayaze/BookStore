using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class BusinessService
    {
        [Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int ServicesId { get; set; }
       
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [ForeignKey("ServicesId")]
        public  Services Services { get; set; }
    }
}
