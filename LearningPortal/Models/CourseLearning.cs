using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPortal.Models
{
    public class CourseLearning
    {
        [Key]
        public int LearnId { get; set; }
        public string Description { get; set; }
        [ForeignKey("Courses")]
        public int CourseId { get; set; }

        public virtual Courses Courses { get; set; }
    }
}