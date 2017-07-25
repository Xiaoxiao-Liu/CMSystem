using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSystem.Models
{
    public class EventSignUp
    {
        public int EventSignUpId { get; set; }
        public virtual Event Event { get; set; }
        public virtual ApplicationUser Customer { get; set; }

        [Required]
        [Display(Name = "SignUp Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SignUpTime { get; set; }
    }
}