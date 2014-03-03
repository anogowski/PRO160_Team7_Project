using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class Patient
    {
        public Patient()
        {
            this.Perscriptions = new List<Perscription>();
        }

        public int PID { get; set; }
        public bool Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> BloodType_id { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Syptoms { get; set; }
        public virtual BloodType BloodType { get; set; }
        public virtual ICollection<Perscription> Perscriptions { get; set; }
    }
}
