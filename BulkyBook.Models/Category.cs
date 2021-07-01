using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name ="Category Name")]
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [MaxLength(200)]
        public string CategoryIcon { get; set; }
        [NotMapped]
        [Display(Name ="Upload Image")]
        public IFormFile formFile1 { get; set; }

        [MaxLength(200)]
        public string CategoryImage { get; set; }
        [NotMapped]
        [Display(Name = "Upload Image")]
        public IFormFile formFile { get; set; }

    }
}
