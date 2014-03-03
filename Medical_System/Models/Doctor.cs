using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            this.Perscriptions = new List<Perscription>();
        }

        public int DID { get; set; }
        public Nullable<int> FID { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Field Field { get; set; }
        public virtual ICollection<Perscription> Perscriptions { get; set; }
    }
}
