using Microsoft.AspNetCore.Builder;

namespace GrupoA.Education.Student.Api.Configurations
{
    public static class SwaggerApiConfiguration
    {
        public static IApplicationBuilder UseEducationSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "EducationGrupoA";
            });

            return app;
        }        
    }
}