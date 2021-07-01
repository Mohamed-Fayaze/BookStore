using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class BusinessPaymentMode
    {
        [Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int PaymentModeId { get; set; }
       
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [ForeignKey("PaymentModeId")]
        public PaymentMode PaymentMode { get; set; }
    }
}
