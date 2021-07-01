using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class FAQ
    {[Key]
        public int Id{ get; set; }

        public int? BussinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Company { get; set; }

  
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [MaxLength(300)]
        public string FAQQuestion { get; set; }

        [MaxLength(300)]
        public string FAQAnswer { get; set; }

        public int? FAQHelpfulCount { get; set; }

        public DateTime QuestionOn { get; set; }

        public DateTime AnswerOn { get; set; }
    }
}
