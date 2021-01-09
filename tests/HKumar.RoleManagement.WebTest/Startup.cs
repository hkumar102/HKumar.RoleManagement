using HKumar.RoleManagement.EFCore;
using HKumar.RoleManagement.Extensions;
using HKumar.RoleManagement.Interfaces.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HKumar.RoleManagement.WebTest
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
            var assembly = typeof(Services.RoleManagementService).Assembly;

            services
                .AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RoleManagement API", Version = "v1" });
            });


            string connectionString = "**********************************";
            services.AddDbContext<RoleManagementDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(RoleManagementDbContext)).FullName));
            });

            services.AddScoped<IDbContextSchema>(factory => new DefaultDbContextSchema(Constants.DB_DEFAULT_SCHEMA));
            services.AddScoped<DbContext, RoleManagementDbContext>();
            services.AddRoleManagement(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
