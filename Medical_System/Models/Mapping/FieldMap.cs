using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class FieldMap : EntityTypeConfiguration<Field>
    {
        public FieldMap()
        {
            // Primary Key
            this.HasKey(t => t.FID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Fields");
            this.Property(t => t.FID).HasColumnName("FID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
