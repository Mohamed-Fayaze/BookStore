using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class BusinessTypeVM
    {
        public IEnumerable<BusinessType> BusinessTypes { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
