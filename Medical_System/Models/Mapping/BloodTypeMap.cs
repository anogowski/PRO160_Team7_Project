using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class BloodTypeMap : EntityTypeConfiguration<BloodType>
    {
        public BloodTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.BID);

            // Properties
            this.Property(t => t.TypeName)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("BloodType");
            this.Property(t => t.BID).HasColumnName("BID");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
        }
    }
}
