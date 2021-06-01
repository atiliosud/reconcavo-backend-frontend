using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WpfApi.Extension.Data;
using WpfApi.Models;

namespace WpfApi.Data.Mapping
{
    public class DrugStoreMapping : EntityTypeConfiguration<DrugStore>
    {
        public override void Map(EntityTypeBuilder<DrugStore> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Name)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.flg_round_the_clock)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(e => e.foundation_date)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(e => e.Name)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.HasOne(e => e.Neightborhood)
          .WithMany(o => o.DrugStores)
          .HasForeignKey(e => e.id_neighborhood);

            builder.ToTable("tbl_drugstores");
        }
    }
}
