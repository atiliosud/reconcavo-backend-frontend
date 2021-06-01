using Microsoft.EntityFrameworkCore;
using WpfApi.Data.Mapping;
using WpfApi.Extension.Data;
using WpfApi.Models;

namespace WpfApi.Data
{
    public class ReconcavaDbContext: DbContext
    {
        public DbSet<DrugStore> Drugstore { get; set; }
        public DbSet<Neighborhood> Neightborhood { get; set; }
     

        public ReconcavaDbContext(DbContextOptions<ReconcavaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.AddConfiguration(new DrugStoreMapping());
            modelBuilder.AddConfiguration(new NeighborhoodMapping());
            

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var directory = System.IO.Directory.GetCurrentDirectory();

        //    if (directory.Contains("IntegrationTest"))
        //    {
        //        directory = directory.Substring(0, directory.Length - 39) + "Services";
        //    }

        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection").Replace("%CONTENTROOTPATH%", directory));
        //}
    }
}
