using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class HealthcareListVM
    {
        public HealthCare Healthcare { get; set; }
        public IEnumerable<HospitalVM> Healthcares { get; set; }
        public IEnumerable<DoctorVM> HealthcareDoctors { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<HospitalDepartment> DepartmentList { get; set; }
        public IEnumerable<Speciality> SpecialityList { get; set; }
        public IEnumerable<Facility> FacilityList { get; set; }
        public IEnumerable<Nationality> NationalityList { get; set; }
        public IEnumerable<Language> LanguageList { get; set; }
        public IEnumerable<Qualification> QualificationList { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }
        public IEnumerable<District> DistrictList { get; set; }
        public IEnumerable<State> StateList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
    public class DoctorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Nationality { get; set; }
        public string Speciality { get; set; }
        public string Experience { get; set; }
        public string Language { get; set; }
        public string Hospital { get; set; }
    }
    public class HospitalVM
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Contact { get; set; }
        public string District { get; set; }
        public string Website { get; set; }
        public string Is24hour { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Image { get; set; }
    }
}
