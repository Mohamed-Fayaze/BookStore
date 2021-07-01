
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class BusinessEmployee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string PhotoUrl { get; set; }
        public int DesignationId { get; set; }
        public int QualificationId { get; set; }
        public int Experience { get; set; }

        [MaxLength(200)]
        public string Nationality { get; set; }
    }
}
