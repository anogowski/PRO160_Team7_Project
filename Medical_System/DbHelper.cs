using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_System
{
    public class DbHelper
    {
        public List<Patient> GetPatients(string[] fields = null)
        {
            using(var context = new MedicalSystemEntities())
            {
                var list = context.Patients;

                FillFields(ref list, fields);

                return list.ToList<Patient>();
            }

        }

        private void FillFields<T>(ref DbSet<T> list, string[] fields = null) where T : class
        {
            for (int i = 0; fields != null && i < fields.Length; i++)
            {
                if (!string.IsNullOrEmpty(fields[i]))
                    list.Include(fields[i]);
            }            
        }

        public List<Doctor> GetDoctors(string[] fields = null)
        {
            using (var context = new MedicalSystemEntities())
            {
                var list = context.Doctors;
                FillFields(ref list, fields);
                return list.ToList<Doctor>();
            }
        }

        public List<Prescription> GetPrescriptions(string[] fields = null)
        {
            using (var context = new MedicalSystemEntities())
            {
                var list = context.Prescriptions;
                FillFields(ref list, fields);
                return list.ToList<Prescription>();  
            }
        }

        public List<Patient> GetDoctorWithPatients(int doc_id, string[] fields = null)
        {       
            using (var context = new MedicalSystemEntities())
            {
                var patients = context.Doctors;
                FillFields(ref patients, fields);
                return patients.Where(d => d.DID == doc_id).SelectMany(p => p.Patients).ToList<Patient>();              
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

        public void AddPrescription(Prescription pre)
        {
            using (var context = new MedicalSystemEntities())
            {
                context.Prescriptions.Add(pre);
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

        public List<Disease> GetDiseases(string[] fields = null)
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
                return context.Diseases.Where(d => d.DISID == disease_id).FirstOrDefault();
            }
        }

        public void updatePatient(Patient updatedPatient)
        {
            using (var context = new MedicalSystemEntities())
            {
                Patient oldPatient = (Patient)context.Patients.Where(p => p.PID == updatedPatient.PID).First();
                oldPatient.SSID = updatedPatient.SSID;
                oldPatient.PhoneNumber = updatedPatient.PhoneNumber;
                oldPatient.FirstName = updatedPatient.FirstName;
                oldPatient.LastName = updatedPatient.LastName;
                oldPatient.HomeAddress = updatedPatient.HomeAddress;
                oldPatient.DateOfBirth = updatedPatient.DateOfBirth;
                oldPatient.Doctors = updatedPatient.Doctors;
                oldPatient.Prescriptions = updatedPatient.Prescriptions;
                context.SaveChanges();
            }
        }

        public void updatePrescriptionNote(Prescription updatedPrescription)
        {
            using (var context = new MedicalSystemEntities())
            {
                Prescription oldPrescription = (Prescription)context.Prescriptions.Where(p => p.PRE_ID == updatedPrescription.PRE_ID).First();
                oldPrescription.Note = updatedPrescription.Note;
                context.SaveChanges();
            }
        }

        public List<Prescription> GetPrescriptionsByPatient(int pid, string[] fields = null)
        {
            using (var context = new MedicalSystemEntities())
            {
                var list = context.Prescriptions;
                FillFields(ref list, fields);
                return list.Where(p=> p.Patient.PID == pid).ToList<Prescription>();
            }
        }
        public string GetPrescriptionNoteByPrescriptionId(int preid)
        {
            using (var context = new MedicalSystemEntities())
            {
                var temp = context.Prescriptions.Where(p => p.PRE_ID == preid).FirstOrDefault();
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
