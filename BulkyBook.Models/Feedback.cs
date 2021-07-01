using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Feedback
    {[Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }

       
        public string UserId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }
        public DateTime? CreatedOn { get; set; }
      
    }
}
