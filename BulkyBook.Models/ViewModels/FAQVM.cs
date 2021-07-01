
using System;
using System.Collections.Generic;
using System.Text;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Models.ViewModels
{
    public class FAQVM
    {
        public FAQ FAQ { get; set; }
        public IEnumerable<FAQ> FAQs { get; set; }
        public IEnumerable<FAQHelpful> FAQHelpful { get; set; }
        public IEnumerable<FAQReportAbuse> FAQReportAbuse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
