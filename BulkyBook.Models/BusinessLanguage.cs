using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class BusinessLanguage
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        public int NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public Language Language { get; set; }
    }
}
