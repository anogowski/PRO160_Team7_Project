using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            // Primary Key
            this.HasKey(t => t.AID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Appointment");
            this.Property(t => t.AID).HasColumnName("AID");
            this.Property(t => t.DateIssued).HasColumnName("DateIssued");
        }
    }
}
