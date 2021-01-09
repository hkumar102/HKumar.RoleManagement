using AutoMapper;
using HKumar.RoleManagement.Automapper;
using HKumar.RoleManagement.EFCore;
using HKumar.RoleManagement.Interfaces.Providers;
using HKumar.RoleManagement.Interfaces.Services;
using HKumar.RoleManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using UnitOfWork.Service;

namespace HKumar.RoleManagement.Extensions
{
    public static class SeriviceCollectionExtension
    {
        public static IServiceCollection AddRoleManagement(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<ICacheProvider, DefaultCacheProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IMenuBuilderService, DefaultMenuBuilderService>();

            services.AddScoped<IRoleManagementService, RoleManagementService>();
            services.AddScoped<IRoleManagementUserInformationProvider, Services.DefaultUserInformationProvider>();

            services
               .AddAutoMapper(typeof(RoleManagementAutoMapperProfile));

            services.RegisterUnitOfWork<Guid, RoleManagementDbContext>(connectionString);

            return services;
        }
    }
}
