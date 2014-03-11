using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class DiseaseTypeMap : EntityTypeConfiguration<DiseaseType>
    {
        public DiseaseTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DTID);

            // Properties
            this.Property(t => t.Name)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DiseaseType");
            this.Property(t => t.DTID).HasColumnName("DTID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
