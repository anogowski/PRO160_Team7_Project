using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class BloodType
    {
        public BloodType()
        {
            this.Patients = new List<Patient>();
        }

        public int BID { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
