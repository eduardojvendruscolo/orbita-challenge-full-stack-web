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
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var educationDatabaseAddress = config.GetConnectionString("EducationDatabaseAddress");
            
            var optionsBuilder = new DbContextOptionsBuilder<EducationDbContext>();
            optionsBuilder.UseNpgsql(educationDatabaseAddress,
                builder =>
                {
                    builder.MigrationsAssembly("GrupoA.Education.Student.Infra.Data");
                });
            optionsBuilder.EnableSensitiveDataLogging();

            return new EducationDbContext(optionsBuilder.Options, config);            
            
        }
    }
}