    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class SubCategories
    {
       
        [Key]
        public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "Enter Category Id")]
        [Display(Name = "Catecory Id")]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Enter Title")]
        [Display(Name = "SubCatecory Title")]
        [StringLength(75, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string SubCategoryName { get; set; }

        [Display(Name = "Time")]
        public DateTime Time { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public string Image { get; set; }
        public virtual Categories Categories { get; set; }
       
        public virtual ICollection<Courses> Courses { get; set; }
    }
}