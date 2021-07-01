using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class PaymentModeVM
    {
        public IEnumerable<PaymentMode> PaymentModes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
