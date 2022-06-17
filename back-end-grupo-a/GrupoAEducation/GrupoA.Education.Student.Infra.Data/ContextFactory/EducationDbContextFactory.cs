using GrupoA.Education.Student.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GrupoA.Education.Student.Infra.Data.ContextFactory
{
    public class EducationDbContextFactory : IDesignTimeDbContextFactory<EducationDbContext>
    {
        public EducationDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().Build();
            var optionsBuilder = new DbContextOptionsBuilder<EducationDbContext>();
            optionsBuilder.UseNpgsql("Host=pgsql.local;Port=15432;Pooling=true;Database=DB_EDUCATION_STUDENT;User Id=grupoa;Password=0b979a178905;",
                builder =>
                {
                    builder.MigrationsAssembly("GrupoA.Education.Student.Infra.Data");
                });
            optionsBuilder.EnableSensitiveDataLogging();

            return new EducationDbContext(optionsBuilder.Options, config);            
            
        }
    }
}