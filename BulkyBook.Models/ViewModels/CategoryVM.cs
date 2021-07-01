using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; }
        public IEnumerable<Category> primaries { get; set; }
        public SubCategory SubCategory { get; set; }
        public IEnumerable<SubCategory> secondaries { get; set; }
        public IEnumerable<SelectListItem> categorylist { get; set; }

        public Automobile Automobile { get; set; }
        public Restaurant Restaurant { get; set; }
        public Event Event { get; set; }
        public Hotels Hotels { get; set; }
        public ProfessionalAssistance ProfessionalAssistance { get; set; }
        public Fitness Fitness { get; set; }
        public Retail Retail { get; set; }
        public TechnicalService TechnicalService { get; set; }
        

        public Business Business { get; set; }
        public BusinessKeyword BusinessKeyword { get; set; }
        public BusinessHour BusinessHour { get; set; }
        public HealthCare HealthCare { get; set; }
        public BusinessEmployee BusinessEmployee { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Promotion> promotions { get; set; }
        public IEnumerable<Promotionimage> promotionimages { get; set; }
        public IEnumerable<Business> BusinessList { get; set; }
        public IEnumerable<BusinessImage> BusinessImage { get; set; }
        public IEnumerable<BusinessPaymentMode> BusinessPaymentModes { get; set; }
        public IEnumerable<SelectListItem> BusinessTypeList { get; set; }
        public IEnumerable<SelectListItem> PrimaryCategoryList { get; set; }
        public IEnumerable<SelectListItem> PaymentModeList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        public IEnumerable<SelectListItem> SpecialityList { get; set; }
        public IEnumerable<SelectListItem> FacilityList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
