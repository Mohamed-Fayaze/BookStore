using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class HealthcareBranchVM
    {
        public HealthcareBranch HealthcareBranch { get; set; }
        public IEnumerable<HealthcareDoctor> HealthcareDoctors { get; set; }
        public IEnumerable<SelectListItem> HospitalTypeList { get; set; }
        public IEnumerable<SelectListItem> TestingLabTypeList { get; set; }
        public IEnumerable<SelectListItem> NursingTypeList { get; set; }
        public IEnumerable<SelectListItem> AmbulatoryTypeList { get; set; }
        public IEnumerable<SelectListItem> MedicalSuppliesTypeList { get; set; }
        public IEnumerable<SelectListItem> MedicalInsuranceTypeList { get; set; }
        public IEnumerable<SelectListItem> PharmaceuticalTypeList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        public IEnumerable<SelectListItem> FacilityList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> DistrictList { get; set; }

    }
}
