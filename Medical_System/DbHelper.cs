using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_System
{
    public class DbHelper
    {
        public List<Patient> GetPatients()
        {
            using(var context = new MedicalSystemEntities())
            {
                var list = context.Patients.ToList<Patient>();
                return list;
            }

        }

        public List<Doctor> GetDoctors()
        {
            using (var context = new MedicalSystemEntities())
            {
                var list = context.Doctors.ToList<Doctor>();
                return list;
            }
        }

        public List<Perscription> GetPerscriptions()
        {
            using (var context = new MedicalSystemEntities())
            {
                var list = context.Perscriptions.ToList<Perscription>();                           
                return list;
            }
        }

        public List<Disease> GetDiseases()
        {
            using (var context = new MedicalSystemEntities())
            {
                var list = context.Diseases.ToList<Disease>();
                return list;
            }
        }

        public List<Patient> GetDoctorWithPatients(int doc_id)
        {       
            using (var context = new MedicalSystemEntities())
            {
                var patients = context.Doctors.Where(d => d.DID == doc_id).SelectMany(p => p.Patients);
                return patients.ToList<Patient>();              
            }
        }

        public bool CanDoctorLogin(string userName, string pwd, out Doctor doctor)
        {
            using (var context = new MedicalSystemEntities())
            {
                doctor = context.Doctors.Where(d => d.UserName.Equals(userName) && d.psw.Equals(pwd)).FirstOrDefault();
                return doctor != null;
            }
        }

        public bool CanAdminLogin(string userName, string pwd, out Administrator admin)
        {
            using (var context = new MedicalSystemEntities())
            {
                admin = context.Administrators.Where(d => d.username.Equals(userName) && d.psw.Equals(pwd)).FirstOrDefault();
                return admin != null;
            }
        }
    }
}
