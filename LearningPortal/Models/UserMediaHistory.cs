using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class UserMediaHistory
    {
        [Key]
        public int UserVideoHistoryId { get; set; }

        [Required(ErrorMessage = "Enter UserId")]
        [Display(Name = "User Id")]
        [ForeignKey("AspNetUser")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter SectionMediaId")]
        [Display(Name = "Section Media Id")]
        [ForeignKey("SectionMedia")]
        public int SectionMediaId { get; set; }

        [Required(ErrorMessage = "Enter WatchedTime")]
        [Display(Name = "WatchedTime")]
        public int WatchedTime { get; set; }

        [Required(ErrorMessage = "Enter UpdatedTime")]
        [Display(Name = "UpdatedTime")]
        public Nullable<bool> UpdatedTime { get; set; }

        public virtual ApplicationUser  AspNetUser { get; set; }

      
        public virtual SectionMedia SectionMedia { get; set; }
    }
}