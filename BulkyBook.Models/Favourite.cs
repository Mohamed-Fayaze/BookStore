using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Favourite
    {[Key]
        public int Id { get; set; }
 
        public string UserId { get; set; }
        public int BusinessId { get; set; }
     
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [ForeignKey("BusinessId")]
        public Business Company { get; set; }
    }
}
