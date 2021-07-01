using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class HealthcareDoctorVM
    {
        public HealthcareDoctor healthcareDoctor { get; set; }
        public Count count { get; set; }
        public IEnumerable<DoctorLanguage> doctorLanguages { get; set; }
        public IEnumerable<HealthcareDoctor> healthcareDoctors { get; set; }
        public IEnumerable<SelectListItem> EmployeeTypes { get; set; }
        public IEnumerable<SelectListItem> SpecialityList { get; set; }
        public IEnumerable<SelectListItem> QualificationList { get; set; }
        public IEnumerable<SelectListItem> NationalityList { get; set; }
        public IEnumerable<SelectListItem> LanguageList { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }
    }
}
