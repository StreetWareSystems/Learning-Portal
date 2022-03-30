using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Enter Title")]
        [Display(Name = "Course Title")]
        [StringLength(55, ErrorMessage = "The {0} must be at least {2} characters long.")]
      
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        [Display(Name = "Course Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Level")]
        [Display(Name = "Course Level")]
        public string Levels { get; set; }

        [Required(ErrorMessage = "Enter Year")]
        [Display(Name = "Course Year")]
        public int Year { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Enter SubCategory Id")]
        [Display(Name = "Sub Category Id")]
        public int SubCategoryId { get; set; }

        [Display(Name = "Time")]
        public DateTime Time { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
       
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime UploadedDate { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<CourseLearning> CourseLearnings { get; set; }
        public virtual SubCategories SubCategories { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}