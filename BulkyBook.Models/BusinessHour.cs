using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class BusinessHour
    {[Key]
        public int Id { get; set; }
        public int BusinessId { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? SundayFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? SundayTo { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? MondayFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? MondayTo { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? TuesdayFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? TuesdayTo { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? WednesdayFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? WednesdayTo { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? ThrusdayFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? ThrusdayTo { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? FridayFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? FridayTo { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? SaturdayFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? SaturdayTo { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? SundayFrom1 { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? SundayTo1 { get; set; }
        public TimeSpan? MondayFrom1 { get; set; }
        public TimeSpan? MondayTo1 { get; set; }
        public TimeSpan? TuesdayFrom1 { get; set; }
        public TimeSpan? TuesdayTo1 { get; set; }
        public TimeSpan? WednesdayFrom1 { get; set; }
        public TimeSpan? WednesdayTo1 { get; set; }
        public TimeSpan? ThrusdayFrom1 { get; set; }
        public TimeSpan? ThrusdayTo1 { get; set; }
        public TimeSpan? FridayFrom1 { get; set; }
        public TimeSpan? FridayTo1 { get; set; }
        public TimeSpan? SaturdayFrom1 { get; set; }
        public TimeSpan? SaturdayTo1 { get; set; }
        public bool IsDualTimings { get; set; }
        
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
