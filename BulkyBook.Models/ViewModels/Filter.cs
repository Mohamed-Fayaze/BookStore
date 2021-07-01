using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class Filter
    {
        public string searchletter { get; set; }
        public int? StateId { get; set; }
        public string State { get; set; }
        public int? categoryId { get; set; }
        public string SubCategory { get; set; }
        public string Speciality { get; set; }
        public int? Department { get; set; }
        public string Facility { get; set; }
        public string Nationality { get; set; }
        public string Language { get; set; }
        public int? District { get; set; }
        public string Gender { get; set; }
        public string HospitalName { get; set; }
        //others
        public string Rating { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public bool? OnlineBooking { get; set; }
        public string ServiceType { get; set; }
        public string PaymentMode { get; set; }
    }

}
