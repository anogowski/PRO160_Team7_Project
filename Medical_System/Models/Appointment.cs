using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class Appointment
    {
        public int AID { get; set; }
        public Nullable<System.DateTime> DateIssued { get; set; }
    }
}
