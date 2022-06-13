using System;
using GrupoA.Education.Student.Infra.Data.Uow;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoA.Education.Student.Api.Configurations
{
    public static class MediatorConfiguration
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(
                config => config.AsScoped(), 
                AppDomain.CurrentDomain.Load("GrupoA.Education.student.Application")
            );
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();        
        }        
    }
}