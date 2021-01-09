using HKumar.RoleManagement.EFCore;
using HKumar.RoleManagement.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HKumar.RoleManagement.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "server=biglynx.database.windows.net;database=Learning_DevSchool;User Id=delhidev; Password=Suqu8169";
            services.AddDbContext<RoleManagementDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IDbContextSchema>(factory => new DefaultDbContextSchema());
        }
    }
}
