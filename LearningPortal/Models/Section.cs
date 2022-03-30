using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }

        [Required(ErrorMessage = "Enter Title")]
        [Display(Name = "Title")]
        public string SectionName { get; set; }

        [ForeignKey("Courses")]
        public int CourseId { get; set; }

        public virtual Courses Courses { get; set; }
       
        public virtual ICollection<SectionMedia> SectionMedia { get; set; }
    }
}