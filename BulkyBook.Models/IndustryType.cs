using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models
{
   public class IndustryType
    {[Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string IndustryTypeName { get; set; }

    }
}
