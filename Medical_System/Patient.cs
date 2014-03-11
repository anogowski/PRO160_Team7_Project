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
    
    public partial class Patient
    {
        public Patient()
        {
            this.Perscriptions = new HashSet<Perscription>();
            this.Doctors = new HashSet<Doctor>();
        }
    
        public int PID { get; set; }
        public string SSID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<System.DateTime> DateOfDeath { get; set; }
        public Nullable<int> BloodType_id { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Syptoms { get; set; }
    
        public virtual BloodType BloodType { get; set; }
        public virtual ICollection<Perscription> Perscriptions { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
