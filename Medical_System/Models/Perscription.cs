using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class Perscription
    {
        public int PERS_ID { get; set; }
        public Nullable<int> DID { get; set; }
        public Nullable<int> PID { get; set; }
        public System.DateTime DateIssued { get; set; }
        public string Note { get; set; }
        public string Reactions { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
