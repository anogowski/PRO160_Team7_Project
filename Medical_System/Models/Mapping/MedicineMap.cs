using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class MedicineMap : EntityTypeConfiguration<Medicine>
    {
        public MedicineMap()
        {
            // Primary Key
            this.HasKey(t => t.MID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Medicine");
            this.Property(t => t.MID).HasColumnName("MID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Note).HasColumnName("Note");
        }
    }
}
