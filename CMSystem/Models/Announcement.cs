using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSystem.Models
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string AnnouncementTitle { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Annoucement")]
        public string AnnouncementContent { get; set; }

        [Required]
        [Display(Name = "Annoucing Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AnnoucingTime { get; set; }


        [Required]
        [Display(Name = "Expiry Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryTime { get; set; }


        public string Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}