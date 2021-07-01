using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models
{
    public class HospitalSEOKeyword
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public int? DistrictId { get; set; }
        public District District { get; set; }
        public int? SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
        public string GenderId { get; set; }
        public int? NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public int? FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int? DepartmentId { get; set; }
        public HospitalDepartment Department { get; set; }
    }
}
