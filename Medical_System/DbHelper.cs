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
                var list = context.Patients.ToList<Patient>();
                return list;
            }
        }

        public List<Doctor> GetDoctors()
        {
            using (var context = new MedicalSystemContext())
            {
                var list = context.Doctors.ToList<Doctor>();
                return list;
            }
        }

        public List<Perscription> GetPerscriptions()
        {
            using (var context = new MedicalSystemContext())
            {
                var list = context.Perscriptions.ToList<Perscription>();                           
                return list;
            }
        }

        public List<Disease> GetDiseases()
        {
            using (var context = new MedicalSystemContext())
            {
                var list = context.Diseases.ToList<Disease>();
                return list;
            }
        }

        public List<Patient> GetDoctorWithPatients(int doc_id)
        {       
            using (var context = new MedicalSystemContext())
            {
                var patients = context.Doctors.Where(d => d.DID == doc_id).SelectMany(p => p.Patients);
                return patients.ToList<Patient>();              
            }
        }

        public bool CanDoctorLogin(string userName, string pwd, out Doctor doctor)
        {
            using (var context = new MedicalSystemContext())
            {
                doctor = context.Doctors.Where(d => d.UserName.Equals(userName) && d.psw.Equals(pwd)).FirstOrDefault();
                return doctor != null;
            }
        }

        public bool CanAdminLogin(string userName, string pwd, out Administrator admin)
        {
            using (var context = new MedicalSystemContext())
            {
                admin = context.Administrators.Where(d => d.username.Equals(userName) && d.psw.Equals(pwd)).FirstOrDefault();
                return admin != null;
            }
        }
    }
}
