using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public partial class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int? BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [Required(ErrorMessage = "Only Numbers")]
        [MaxLength(10)]
        public string HouseNo { get; set; }
        [Required(ErrorMessage = "Street is Required")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Please Enter Valid Address")]
        public string AddressField { get; set; }
        [Required(ErrorMessage = "Area is Required")]
        [MaxLength(60)]
        public string AreaStreet { get; set; }
        [Required(ErrorMessage = "City is Required")]
        [MaxLength(60)]
        public string CityTown { get; set; }
        [Required(ErrorMessage = "State is Required")]
        [MaxLength(60)]
        public string StateProvinceRegion { get; set; }
        [Required(ErrorMessage = "Country is Required")]

        [StringLength(60, MinimumLength = 4, ErrorMessage = "Country must be min 4 digits")]
        public string Country { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "This is not valid Pincode")]
        public string Pincode { get; set; }
        [Required(ErrorMessage = "Landmark is Required")]
        [MaxLength(60)]
        [DataType(DataType.PostalCode)]
        //public string Website { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Please Enter Valid Landmark")]
        public string Landmark { get; set; }
        public string AddressType { get; set; }
        public bool IsPrimary { get; set; }

        public virtual ICollection<Email> EmailTables { get; set; }
        public virtual ICollection<Landline> LandlineTables { get; set; }
        public virtual ICollection<Location> LocationTables { get; set; }
        public virtual ICollection<Mobile> MobileTables { get; set; }
        public virtual ICollection<Social> SocialTables { get; set; }
    }
}
