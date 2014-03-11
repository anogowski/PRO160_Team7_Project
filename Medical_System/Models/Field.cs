using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class Field
    {
        public Field()
        {
            this.Doctors = new List<Doctor>();
        }

        public int FID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
