using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class UserProfileVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public UserPrivate UserPrivate { get; set; }
        public Preference Preference { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }
        public IEnumerable<SelectListItem> MaritalstatusList { get; set; }
        public IEnumerable<SelectListItem> OccupationList { get; set; }
        public IEnumerable<SelectListItem> PositionList { get; set; }
        public IEnumerable<SelectListItem> LanguageList { get; set; }
        public IEnumerable<SelectListItem> IndustryList { get; set; }
        public IEnumerable<Address> addressTable { get; set; }
    }


}
