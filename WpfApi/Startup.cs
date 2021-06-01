using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfApi.Data;
using WpfApi.Repository;
using WpfApi.Repository.Interfaces;

namespace WpfApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddScoped<ReconcavaDbContext>();
            services.AddDbContext<ReconcavaDbContext>(option => option.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ProjetosIterative\WpfApplication\WpfApi\AppData\WpfApplication.mdf;Integrated Security=True"));//(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WpfApplication;"));
            services.AddTransient<IDrugStoreRepository, DrugStoreRepository>();
            services.AddTransient<INeightborhoodRepository, NeightborhoodRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WpfApi");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

       

        }
    }
}
