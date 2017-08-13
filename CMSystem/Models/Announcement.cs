using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSystem.Models
{
    public class Announcement
    {
        //The primary key
        public int AnnouncementId { get; set; }

        //Title of annoucement. Display as"Title" in the view, requring content.
        [Required]
        [Display(Name = "Title")]
        public string AnnouncementTitle { get; set; }

        //The content of annoucement.
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Annoucement")]
        public string AnnouncementContent { get; set; }

        //The date time of annoucing time. The format is {0:yyyy-MM-dd}
        [Required]
        [Display(Name = "Annoucing Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AnnoucingTime { get; set; }

        //The date time of expiry time, help the system filter expired annoucement.
        [Required]
        [Display(Name = "Expiry Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryTime { get; set; }


        public int Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}