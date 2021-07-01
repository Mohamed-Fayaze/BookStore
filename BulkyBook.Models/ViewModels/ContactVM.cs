using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Models.ViewModels
{
    public class ContactVM
    {
        public Business Business { get; set; }
        public Address addressTable { get; set; }
        public IEnumerable<Address> AddressTable { get; set; }

        //public EmailTable emailTable { get; set; }
        public List<Email> EmailTable { get; set; }

        //public LandlineTable landlineTable { get; set; }
        public List<Landline> LandlineTable { get; set; }

        public Location locationTable { get; set; }
        //public IEnumerable<LocationTable> LocationTable { get; set; }

        public List<Mobile> MobileTable { get; set; }
        //public SocialTable socialTable { get; set; }
        public List<Social> SocialTable { get; set; }





    }
}
