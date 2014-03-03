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
        public List<Patient> GetDoctors()
        {
            using(var context = new MedicalSystemContext())
            {
                var list = from d in context.Patients
                           select d;
                return list.ToList<Patient>();
            }

        }
    }
}
