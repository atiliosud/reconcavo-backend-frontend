using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WpfApi.Extension.Data
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
