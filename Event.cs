//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HollywoodTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.EventDetails = new HashSet<EventDetail>();
        }
    
        public long EventID { get; set; }
        public long TounamentID { get; set; }
        public string EventName { get; set; }
        public short EventNumber { get; set; }
        public System.DateTime EventDateTime { get; set; }
        public System.DateTime EventEndDateTime { get; set; }
        public bool AutoClose { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventDetail> EventDetails { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
