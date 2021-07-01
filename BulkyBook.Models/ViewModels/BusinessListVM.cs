using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class BusinessListVM
    {
        public IEnumerable<Business> BusinessList { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Address address { get; set; }
        public Automobile Automobile { get; set; }
        public Restaurant Restaurant { get; set; }
        public Event Event { get; set; }
        public Hotels Hotels { get; set; }
        public ProfessionalAssistance ProfessionalAssistance { get; set; }
        public Fitness Fitness { get; set; }
        public Retail Retail { get; set; }
        public TechnicalService TechnicalService { get; set; }
        public Promotion Promotion { get; set; }
        public Promotionimage Promotionimage { get; set; }
        public IEnumerable<Address> addressTable { get; set; }
        public IEnumerable<Mobile> mobileTable { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Promotion> promotions { get; set; }
        public IEnumerable<Promotionimage> promotionimages { get; set; }
        public IEnumerable<HospitalDepartment> DepartmentList { get; set; }
        public IEnumerable<Facility> FacilityList { get; set; }
        public IEnumerable<Speciality> SpecialityList { get; set; }
        public IEnumerable<Language> LanguageList { get; set; }
        public IEnumerable<PaymentMode> PaymentModeList { get; set; }
        public IEnumerable<BusinessLanguage> BusinessNationality { get; set; }
        public Contact Contact { get; set; }
        public NewAddress Address { get; set; }
        public IEnumerable<SelectListItem> OnlineBooking { get; set; }
    }
}
