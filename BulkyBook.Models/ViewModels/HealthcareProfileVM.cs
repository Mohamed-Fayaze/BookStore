using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class HealthcareProfileVM
    {
        public Business Business { get; set; }
        public BusinessKeyword BusinessKeyword { get; set; }
        public BusinessHour BusinessHour { get; set; }
        public HealthCare HealthCare { get; set; }
        public BusinessEmployee BusinessEmployee { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<Address> Address { get; set; }
        public IEnumerable<BusinessImage> BusinessImage { get; set; }
        public IEnumerable<BusinessPaymentMode> BusinessPaymentModes { get; set; }
        public IEnumerable<SelectListItem> BusinessTypeList { get; set; }
        public IEnumerable<SelectListItem> PrimaryCategoryList { get; set; }
        public IEnumerable<SelectListItem> PaymentModeList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        public IEnumerable<SelectListItem> SpecialityList { get; set; }
        public IEnumerable<SelectListItem> FacilityList { get; set; }
    }
}
