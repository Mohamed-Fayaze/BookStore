using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace BulkyBook.Models
{
    public class Designation
    {
        [Key]

        public int Id { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }
       
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> categoryList { get; set; }

    }
}
