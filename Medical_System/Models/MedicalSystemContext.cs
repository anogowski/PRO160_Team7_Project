using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Medical_System.Models.Mapping;

namespace Medical_System.Models
{
    public partial class MedicalSystemContext : DbContext
    {
        static MedicalSystemContext()
        {
            Database.SetInitializer<MedicalSystemContext>(null);
        }

        public MedicalSystemContext()
            : base("Name=MedicalSystemContext")
        {
        }

        //public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseaseType> DiseaseTypes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Perscription> Perscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new AdministratorMap());
            modelBuilder.Configurations.Add(new AppointmentMap());
            modelBuilder.Configurations.Add(new BloodTypeMap());
            modelBuilder.Configurations.Add(new DiseaseMap());
            modelBuilder.Configurations.Add(new DiseaseTypeMap());
            modelBuilder.Configurations.Add(new DoctorMap());
            modelBuilder.Configurations.Add(new FieldMap());
            modelBuilder.Configurations.Add(new MedicineMap());
            modelBuilder.Configurations.Add(new PatientMap());
            modelBuilder.Configurations.Add(new PerscriptionMap());
        }
    }
}
