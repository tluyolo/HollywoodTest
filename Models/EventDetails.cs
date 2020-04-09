using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HollywoodTest.Models
{
    public class EventDetails //app Model
    {
        public int EventDetailID { get; set; }
        public int EventID { get; set; }
        public int EventDetailStatusID { get; set; }
        public String EventDetailName { get; set; }
        public int EventDetailNumber { get; set; }
        public double EventDetailOdd { get; set; }
        public int FinishingPositio { get; set; }
        public int FirstTime { get; set; }
    }
}