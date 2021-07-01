using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class BusinessProfileVM
    {
        public Business Business { get; set; }
        public BusinessKeyword BusinessKeyword { get; set; }
        public IEnumerable<BusinessService> BusinessServices { get; set; }
        public IEnumerable<BusinessCertification> BusinessCertification { get; set; }
        public IEnumerable<BusinessImage> BusinessImage { get; set; }
        public BusinessHour BusinessHour { get; set; }
        public IEnumerable<BusinessPaymentMode> BusinessPaymentModes { get; set; }
        public IEnumerable<SelectListItem> BusinessTypeList { get; set; }
        public IEnumerable<SelectListItem> PrimaryCategoryList { get; set; }
        public IEnumerable<SelectListItem> PaymentModeList { get; set; }
        public IEnumerable<SelectListItem> ServicesList { get; set; }
        public Address address { get; set; }
        public IEnumerable<Address> addressTable { get; set; }
        public FAQ faq { get; set; }
        public IEnumerable <FAQ> FAQs{ get; set; }
        public IEnumerable<Mobile> mobileTable { get; set; }
        public IEnumerable<Email> emailTable { get; set; }
        public IEnumerable<Landline> landlineTable { get; set; }
        public IEnumerable<Social> socialTable { get; set; }
        public IEnumerable<Location> locationTable { get; set; }
        //REVIEW

        //public ReviewRating ReviewRating { get; set; }
        //public IEnumerable<ReviewRating> ReviewRatings { get; set; }
        //public IEnumerable<SelectListItem> OtherList { get; set; }
        //public IEnumerable<Helpful> Helpful { get; set; }
        //public IEnumerable<ReportAbuse> ReportAbuse { get; set; }
        public ReviewRatingVM ReviewRatingVM { get; set; }
        //public Address Address { get; set; }

        public List<HealthcareBranch> HealthcareBranches { get; set; }


    }
}
