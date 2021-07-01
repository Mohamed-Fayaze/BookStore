using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
   public class Promotionimage
    {
        [Key]
        public int Id { get; set; }
        public string Images { get; set; }
        public int PromotionId { get; set; }
        [ForeignKey("PromotionId")]
        public Promotion Promotion { get; set; }
    }
}
