using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WpfApi.Extension.Data;
using WpfApi.Models;

namespace WpfApi.Data.Mapping
{
    public class NeighborhoodMapping : EntityTypeConfiguration<Neighborhood>
    {
        public override void Map(EntityTypeBuilder<Neighborhood> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Name)
               .HasColumnType("varchar(50)")
               .IsRequired();           

            builder.ToTable("tbl_neighborhood");
        }
    }
}
