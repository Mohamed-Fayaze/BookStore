using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Log
    {
     [Key]
        public int Id { get; set; }

  
        public string UserId { get; set; }
        public DateTime? LoginDate { get; set; }
        public TimeSpan? LoginTime { get; set; }
        public DateTime? LogoutDate { get; set; }
        public TimeSpan? LogoutTime { get; set; }
       
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
