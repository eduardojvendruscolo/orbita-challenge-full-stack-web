using GrupoA.Education.Student.Infra.Data.Mappings.Students;
using Microsoft.EntityFrameworkCore;

namespace GrupoA.Education.Student.Infra.Data.Extensions
{
    public static class ConfigureEntityMaps
    {
        public static void AddMappings(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AcademicStudentMap());
        }        
    }
}