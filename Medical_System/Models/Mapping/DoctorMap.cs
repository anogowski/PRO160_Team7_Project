using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class DoctorMap : EntityTypeConfiguration<Doctor>
    {
        public DoctorMap()
        {
            // Primary Key
            this.HasKey(t => t.DID);

            // Properties
            this.Property(t => t.HomeAddress)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.PhoneNumber)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Doctor");
            this.Property(t => t.DID).HasColumnName("DID");
            this.Property(t => t.FID).HasColumnName("FID");
            this.Property(t => t.HomeAddress).HasColumnName("HomeAddress");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");

            // Relationships
            this.HasOptional(t => t.Field)
                .WithMany(t => t.Doctors)
                .HasForeignKey(d => d.FID);

        }
    }
}
