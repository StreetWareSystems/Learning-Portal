using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPortal.Models
{
    public class SectionMedia
    {
       [Key]
        public int SectionMediaId { get; set; }
        public string VideoTitle { get; set; }
        public string Videotype { get; set; }
        public string VideoUrl { get; set; }
        [Required(ErrorMessage = "Enter Section Id")]
        [Display(Name = " Section Id")]
        [ForeignKey("Section")]
        public int SectionId { get; set; }
       public int VideoDuration { get; set; }
        public virtual Section Section { get; set; }
        
        public virtual ICollection<UserMediaHistory> UserMediaHistories { get; set; }
    }
}