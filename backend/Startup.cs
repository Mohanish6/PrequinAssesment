using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InvestorCommitments
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });


            // Add DbContext 
            services.AddDbContext<AppDbContext>(options =>
              options.UseInMemoryDatabase("InMemoryDb"));
        }

        // Configure middleware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable Swagger for development
            if (env.IsDevelopment())
            {
               
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            // Map controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Seed the database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}