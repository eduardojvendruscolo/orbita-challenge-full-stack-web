using GrupoA.Education.Student.Application.AcademicStudent.Services;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Common.Notification;
using GrupoA.Education.Student.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoA.Education.Student.Api.Configurations
{
    public static class EducationServicesConfiguration
    {
        public static void AddEducationServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationContext, NotificationContext>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();      
            services.AddScoped<IAcademicStudentService, AcademicStudentService>();

        }        
    }
}