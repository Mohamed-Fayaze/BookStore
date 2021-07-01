using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace BulkyBook.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> categoryList { get; set; }

    }
}
