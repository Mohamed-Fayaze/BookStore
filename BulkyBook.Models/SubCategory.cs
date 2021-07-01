using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BulkyBook.Models
{
    public  class SubCategory
    {[Key]

        public int SecondaryId { get; set; }

        [MaxLength(120)]
        public string SecondaryName { get; set; }

        [MaxLength(200)]
        public string SubCategoryIcon { get; set; }
        [NotMapped]
        [Display(Name = "Upload Image")]
        public IFormFile formFile2 { get; set; }

        [MaxLength(200)]
        public string SubCategoryImage { get; set; }
        [NotMapped]
        [Display(Name = "Upload Image")]
        public IFormFile formFile3 { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public Category PrimaryCategory { get; set; }
 
      
    }
}
