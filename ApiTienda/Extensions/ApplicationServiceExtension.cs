using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestruture.UnitOfWork;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)=>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
        });
        public static void AddAplicacionServices(this IServiceCollection services)
        {
            //services.AddScoped<IPais, PaisRepository>();
            //services.AddScoped<IRegion, RegionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}