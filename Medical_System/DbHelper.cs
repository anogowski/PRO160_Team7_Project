using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public List<Perscription> GetPrescriptions()
        {
            using (var context = new MedicalSystemEntities())
            {
                var list = context.Perscriptions.ToList<Perscription>();                           
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

        public void AddPatient(Patient patient)
        {
            using (var context = new MedicalSystemEntities())
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }
        }

        public void AddPrescription(Perscription pers)
        {
            using (var context = new MedicalSystemEntities())
            {
                context.Perscriptions.Add(pers);
                context.SaveChanges();
            }
        }

        public void AddAppointment(Appointment app)
        {
            using (var context = new MedicalSystemEntities())
            {
                context.Appointments.Add(app);
                context.SaveChanges();
            }
        }

        public void AddMedicine(Medicine medi)
        {
            using (var context = new MedicalSystemEntities())
            {
                context.Medicines.Add(medi);
                context.SaveChanges();
            }
        }

        public void AddDoctor(Doctor doc)
        {
            using (var context = new MedicalSystemEntities())
            {
                context.Doctors.Add(doc);
                context.SaveChanges();
            }
        }

        public List<Disease> GetDiseases()
        {
            using (var context = new MedicalSystemEntities())
            {
                return context.Diseases.ToList<Disease>();
            }
        }

        public Disease GetDiseasesById(int disease_id)
        {
            using (var context = new MedicalSystemEntities())
            {
                return context.Diseases.Where(d => d.DEAID == disease_id).FirstOrDefault();
            }
        }

        public List<Perscription> GetPrescriptionsByPatient(int pid)
        {
            using (var context = new MedicalSystemEntities())
            {
                return context.Perscriptions.Where(p=> p.Patient.PID == pid).ToList<Perscription>();
            }
        }

        public string GetPrescriptionNoteByPrescriptionId(int pid)
        {
            using (var context = new MedicalSystemEntities())
            {
                var temp = context.Perscriptions.Where(p => p.PERS_ID == pid).FirstOrDefault();
                return temp == null ? null : temp.Note;
            }
        }


       
    }

    public static class DbExtension
    {
        public static ObservableCollection<T> ToObserserverCollection<T>(this List<T> list)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (var item in list)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
