using Business.Contract;
using Business.Implement;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using DataAccess.Models;
using DataAccess.Models.Mapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped<ITurnosRepository, TurnosRepository>();

            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddScoped<ITurnosServices, TurnosServices>();
            services.AddAutoMapper(typeof(TurnoProfileMap));

            return services;
        }
        
    }
}
