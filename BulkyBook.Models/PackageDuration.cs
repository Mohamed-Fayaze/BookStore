using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class PackageDuration
    {
        [Key]
        public int Id { get; set; }
        public int PackageId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DurationType { get; set; }
        [Required]
        public int? DurationPeriod { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public virtual Package Package { get; set; }
    }
}
