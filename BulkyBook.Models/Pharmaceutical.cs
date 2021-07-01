
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Pharmaceutical
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        public string Type { get; set; }
        public bool DoorDelivery { get; set; }
        public bool OnlineBooking { get; set; }
        public int MinOrderPrice { get; set; }
        public int MinPrice { get; set; }
    }
}
