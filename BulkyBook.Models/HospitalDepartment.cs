using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models
{
   public class HospitalDepartment
    {[Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string DepartmentName { get; set; }

    }
}
