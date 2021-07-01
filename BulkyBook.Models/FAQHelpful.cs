using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
   public class FAQHelpful
    {[Key]
        public int Id { get; set; }

      
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int FAQId { get; set; }

        [ForeignKey("FAQId")]
        public FAQ FAQ { get; set; }
    }
}
