using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class HealthcareBranch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [Display(Name="Healthcare")]
        public int HealthcareId { get; set; }
        [ForeignKey("HealthcareId")]
        public HealthCare Healthcare { get; set; }
        [Display(Name = "HospitalType")]
        public int? HospitalTypeId { get; set; }
        [ForeignKey("HospitalTypeId")]
        public HospitalType HospitalType { get; set; }
        [Display(Name = "TestingLabType")]
        public int? TestingLabTypeId { get; set; }
        [ForeignKey("TestingLabTypeId")]
        public TestingLabType TestingLabType { get; set; }
        [Display(Name = "NursingType")]
        public int? NursingTypeId { get; set; }
        [ForeignKey("NursingTypeId")]
        public NursingType NursingType { get; set; }
        [Display(Name = "AmbulatoryType")]
        public int? AmbulatoryTypeId { get; set; }
        [ForeignKey("AmbulatoryTypeId")]
        public AmbulatoryType AmbulatoryType { get; set; }
        [Display(Name = "MedicalSuppliesType")]
        public int? MedicalSuppliesTypeId { get; set; }
        [ForeignKey("MedicalSuppliesTypeId")]
        public MedicalSuppliesType MedicalSuppliesType { get; set; }
        [Display(Name = "MedicalInsuranceType")]
        public int? MedicalInsuranceTypeId { get; set; }
        [ForeignKey("MedicalInsuranceTypeId")]
        public MedicalInsuranceType MedicalInsuranceType { get; set; }
        [Display(Name = "PharmaceuticalType")]
        public int? PharmaceuticalTypeId { get; set; }
        [ForeignKey("PharmaceuticalTypeId")]
        public PharmaceuticalType PharmaceuticalType { get; set; }
        [Display(Name = "HospitalDepartment")]
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public HospitalDepartment Department { get; set; }
        [Display(Name = "Facility")]
        public int? FacilityId { get; set; }
        [ForeignKey("FacilityId")]
        public Facility Facility { get; set; }
        [Required]
        [MaxLength(60)]
        [Display(Name = "ContactPersonName")]
        public string ContactPersonName { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "ContactNo1")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo1 { get; set; }
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "ContactNo2")]
        public string ContactNo2 { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "EmergencyContactNo")]
        public string EmergencyContactNo { get; set; }
        [MaxLength(30)]
        [Display(Name = "SocialMediaName")]
        public string SocialMediaName { get; set; }
        [MaxLength(120)]
        [DataType(DataType.Url)]
        [Display(Name = "SocialMediaURL")]
        public string SocialMediaURL { get; set; }
        [Required]
        [MaxLength(120)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "State")]
        [Required]
        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        [Display(Name = "District")]
        [Required]
        public int? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
        [MaxLength(200)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string UploadImage { get; set; }
        [MaxLength(300)]
        public string keyword { get; set; }
    }
}
