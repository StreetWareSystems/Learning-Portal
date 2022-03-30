using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class CourseTag
    {
        [Key]
        public int CourseTagId { get; set; }

        [Required(ErrorMessage = "Enter Tag Id")]
        [Display(Name = "Tag Id")]
        [ForeignKey("TagManager")]
        public int TagId { get; set; }

        [Required(ErrorMessage = "Enter Course Id")]
        [Display(Name = "Course Id")]
        [ForeignKey("Courses")]
        public int CourseId { get; set; }

        public virtual TagManager TagManager { get; set; }
        public virtual Courses Courses { get; set; }
        
    }
}