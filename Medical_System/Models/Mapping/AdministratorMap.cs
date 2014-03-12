using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Medical_System.Models.Mapping
{
    public class AdministratorMap : EntityTypeConfiguration<Administrator>
    {
        public AdministratorMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.username)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.psw)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Administrator");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.psw).HasColumnName("psw");
        }
    }
}
