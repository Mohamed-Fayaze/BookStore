using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class UserPackage
    {
        public int Id { get; set; }

     
        public string UserId { get; set; }
        public int PackageDurationId { get; set; }
        public DateTime? PurchasedOn { get; set; }
        [ForeignKey("PackageDurationId")]
        public PackageDuration PackageDuration { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
