using System;
using System.IO;
using System.Reflection;
using GrupoA.Education.Student.Api.Configurations;
using GrupoA.Education.Student.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoA.Education.Student.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Configure Services...");
            
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });
           
            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
            
            services.AddDbContext<EducationDbContext>();
            services.AddFluentValidation();
            services.AddControllers();
            services.AddMediator();
            services.AddAutoMapper();
            services.AddEducationServices();
            
            services.AddSwaggerGen(c =>
                {
                    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                }
            );
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseApiVersioning();
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEducationSwagger();

        }
        
    }
}