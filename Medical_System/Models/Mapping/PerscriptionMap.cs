using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class PerscriptionMap : EntityTypeConfiguration<Perscription>
    {
        public PerscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.PERS_ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Perscription");
            this.Property(t => t.PERS_ID).HasColumnName("PERS_ID");
            this.Property(t => t.DID).HasColumnName("DID");
            this.Property(t => t.PID).HasColumnName("PID");
            this.Property(t => t.DateIssued).HasColumnName("DateIssued");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.Reactions).HasColumnName("Reactions");

            // Relationships
            this.HasOptional(t => t.Doctor)
                .WithMany(t => t.Perscriptions)
                .HasForeignKey(d => d.DID);
            this.HasOptional(t => t.Patient)
                .WithMany(t => t.Perscriptions)
                .HasForeignKey(d => d.PID);

        }
    }
}
