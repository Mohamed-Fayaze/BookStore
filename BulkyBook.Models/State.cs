using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace BulkyBook.Models
{
    public class State
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }


    }
}
