using System;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoA.Education.Student.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("GrupoA.Education.Student.Application");
            services.AddAutoMapper(assembly);
        }        
    }
}