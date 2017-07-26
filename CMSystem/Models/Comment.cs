using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSystem.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public virtual Announcement Announcement { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Comment Content")]
        [DataType(DataType.MultilineText)]
        public string CommentContent { get; set; }


        public bool Anonymous { get; set; }

        [Required]
        [Display(Name = "Comment Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CommentTime { get; set; }

    }
}