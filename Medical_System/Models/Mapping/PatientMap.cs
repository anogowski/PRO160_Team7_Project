using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class PatientMap : EntityTypeConfiguration<Patient>
    {
        public PatientMap()
        {
            // Primary Key
            this.HasKey(t => t.PID);

            // Properties
            this.Property(t => t.HomeAddress)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.PhoneNumber)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Patient");
            this.Property(t => t.PID).HasColumnName("PID");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.BloodType_id).HasColumnName("BloodType_id");
            this.Property(t => t.HomeAddress).HasColumnName("HomeAddress");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Syptoms).HasColumnName("Syptoms");

            // Relationships
            this.HasOptional(t => t.BloodType)
                .WithMany(t => t.Patients)
                .HasForeignKey(d => d.BloodType_id);

        }
    }
}
