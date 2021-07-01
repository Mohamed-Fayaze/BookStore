using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [MaxLength(60)]
        public string ContactPersonName { get; set; }

        [MaxLength(14)]
        public string ContactNumber { get; set; }

        [MaxLength(14)]
        public string EmergencyContactNumber { get; set; }

        [MaxLength(60)]
        public string Website { get; set; }

        [MaxLength(60)]
        public string SocialName { get; set; }

        [MaxLength(200)]
        public string SocialURL { get; set; }
    }
}
