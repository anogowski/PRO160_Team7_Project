//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medical_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public Doctor()
        {
            this.Perscriptions = new HashSet<Perscription>();
            this.Patients = new HashSet<Patient>();
        }
    
        public int DID { get; set; }
        public Nullable<int> FID { get; set; }
        public string UserName { get; set; }
        public string psw { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual Field Field { get; set; }
        public virtual ICollection<Perscription> Perscriptions { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
