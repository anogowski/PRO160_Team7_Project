using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class DiseaseMap : EntityTypeConfiguration<Disease>
    {
        public DiseaseMap()
        {
            // Primary Key
            this.HasKey(t => t.DEAID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Disease");
            this.Property(t => t.DEAID).HasColumnName("DEAID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
