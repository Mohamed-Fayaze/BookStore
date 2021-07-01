using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Report
    {
        [Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }

        
        public string UserId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
