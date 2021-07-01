using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace BulkyBook.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> StateList { get; set; }

    }
}
