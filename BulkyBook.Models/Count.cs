using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace BulkyBook.Models
{
    public class Count
    {
        [Key]

        public int Id { get; set; }

        public int viewcount { get; set; }

        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public HealthcareDoctor Doctor { get; set; }

    }
}
