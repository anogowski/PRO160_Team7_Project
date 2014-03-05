using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical_System.Models;

namespace Medical_System
{
    public class DbHelper
    {
        public List<Patient> GetPatients()
        {
            using(var context = new MedicalSystemContext())
            {
                var list = from p in context.Patients
                           select p;
                return list.ToList<Patient>();
            }

        }

        public List<Doctor> GetDoctors()
        {
            using (var context = new MedicalSystemContext())
            {
                var list = from d in context.Doctors
                           select d;
                return list.ToList<Doctor>();
            }
        }
    }
}
