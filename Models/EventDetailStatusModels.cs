using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HollywoodTest.Models
{
    public class EventDetailStatusModels
    {
        [Display(Name = "EventDetailstatusID")]
        public short EventDetailstatusID { get; set; }
        
        [Required(ErrorMessage = "Event Detail status ID is required.")]
        public String EventDetailstatus{get;set;}

    }
}