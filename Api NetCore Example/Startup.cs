using Api_NetCore_Example.Database;
using Api_NetCore_Example.Repositories;
using Api_NetCore_Example.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore_Example
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

            services.AddDbContext<TallerDbContext>(options =>
                options.UseNpgsql("Server=localhost;Database=talleruno;Port=5432;User Id=postgres;Password=postgres")
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_NetCore_Example", Version = "v1" });
            });


            services.AddTransient<ICustomerService, CustomerService>();

            var contextOptions = new DbContextOptionsBuilder<TallerDbContext>()
            .UseNpgsql(@"Server=localhost;Database=talleruno;Port=5432;User Id=postgres;Password=postgres")
            .Options;

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            //services.AddTransient<ICustomerRepository>(x => new CustomerRepository(TallerDbContext));
            //services.AddSingleton<ICustomerRepository>(x => new CustomerRepository());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api_NetCore_Example v1"));
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
