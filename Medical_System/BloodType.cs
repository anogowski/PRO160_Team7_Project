//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medical_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class BloodType
    {
        public BloodType()
        {
            this.Patients = new HashSet<Patient>();
        }
    
        public int BID { get; set; }
        public string TypeName { get; set; }
    
        public virtual ICollection<Patient> Patients { get; set; }
    }
}