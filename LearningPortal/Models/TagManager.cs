using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class TagManager
    {
        [Key]
        public int TagId { get; set; }

        [Required(ErrorMessage = "Enter TagManager Name.")]
        [Display(Name = "TagManager Name")]
        [StringLength(55, ErrorMessage = "The {0} must be at least {2} characters long.")]
        
        public string TagName { get; set; }

        
        public virtual ICollection<CourseTag> CourseTag { get; set; }
    }
}