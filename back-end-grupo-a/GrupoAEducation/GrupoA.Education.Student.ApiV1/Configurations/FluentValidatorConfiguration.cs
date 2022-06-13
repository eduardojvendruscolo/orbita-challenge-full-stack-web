using System;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoA.Education.Student.Api.Configurations
{
    public static class FluentValidatorConfiguration
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddControllers(options => { options.Filters.Add(typeof(FluentValidationFilters)); });
            services.AddMvcCore()
                .AddFluentValidation(c =>
                {
                    c.RegisterValidatorsFromAssemblies(new[]
                    {
                        AppDomain.CurrentDomain.Load("GrupoA.Education.Student.Application"),
                    });

                    c.DisableDataAnnotationsValidation = false;
                });
            services.AddScoped<FluentValidationFilters>();
            services.AddScoped<IValidatorInterceptor, FluentValidationInterceptor>();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);            
        }
    }


}