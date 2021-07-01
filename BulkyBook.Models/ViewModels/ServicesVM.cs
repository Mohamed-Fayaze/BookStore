using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class ServicesVM
    {
        public IEnumerable<Services> Services { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
