using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class HealthcareVM
    {
        public HealthCare healthcare { get; set; }
        public IEnumerable<HealthcareBranch> Branches { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
