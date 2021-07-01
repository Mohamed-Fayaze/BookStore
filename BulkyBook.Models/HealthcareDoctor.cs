using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class HealthcareDoctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public HealthcareBranch HealthcareBranch { get; set; }
        [Display(Name = "DoctorType")]
        public int DoctorTypeId { get; set; }
        [ForeignKey("DoctorTypeId")]
        public EmployeeType EmployeeType { get; set; }
        [Display(Name = "Speciality")]
        public int SpecialityId { get; set; }
        [ForeignKey("SpecialityId")]
        public Speciality Speciality { get; set; }
        [Display(Name = "Qualification")]
        public int? QualificationId { get; set; }
        [ForeignKey("QualificationId")]
        public Qualification Qualification { get; set; }
        public int Experience { get; set; }
        [Display(Name = "Nationality")]
        public int NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }
        [MaxLength(500)]
        public string About { get; set; }
        [Display(Name = "Gender")]
        [MaxLength(30)]
        public string gender { get; set; }
        [MaxLength(30)]
        public string SundayFrom { get; set; }
        [MaxLength(30)]
        public string SundayTo { get; set; }
        [MaxLength(30)]
        public string MondayFrom { get; set; }
        [MaxLength(30)]
        public string MondayTo { get; set; }
        [MaxLength(30)]
        public string TuesdayFrom { get; set; }
        [MaxLength(30)]
        public string TuesdayTo { get; set; }
        [MaxLength(30)]
        public string WednesdayFrom { get; set; }
        [MaxLength(30)]
        public string WednesdayTo { get; set; }
        [MaxLength(30)]
        public string ThrusdayFrom { get; set; }
        [MaxLength(30)]
        public string ThrusdayTo { get; set; }
        [MaxLength(30)]
        public string FridayFrom { get; set; }
        [MaxLength(30)]
        public string FridayTo { get; set; }
        [MaxLength(30)]
        public string SaturdayFrom { get; set; }
        [MaxLength(30)]
        public string SaturdayTo { get; set; }
        [MaxLength(200)]
        [Display(Name = "DoctorPhoto")]
        public string DoctorPhoto { get; set; }
        [NotMapped]
        public List<int> Languages { get; set; }
        public ICollection<DoctorLanguage> DoctorLanguages { get; set; }
        [MaxLength(300)]
        public string keyword { get; set; }
    }
}
