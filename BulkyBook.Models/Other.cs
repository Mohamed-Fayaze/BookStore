using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class Other
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Display(Name="Other Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
