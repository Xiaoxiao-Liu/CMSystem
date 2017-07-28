using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSystem.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string EventDescription { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }


        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Creation Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }

        [Required]
        [Display(Name = "Deadline")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }
        public int Capacity { get; set; }
        public string Role { get; set; }
   
    }
}