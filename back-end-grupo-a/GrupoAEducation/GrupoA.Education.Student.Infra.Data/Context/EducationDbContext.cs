using GrupoA.Education.Student.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GrupoA.Education.Student.Infra.Data.Context
{
    public class EducationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public EducationDbContext(DbContextOptions<EducationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        
        public DbSet<Domain.Student.Entities.Student> Students { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var orbitaStringConnection = _configuration.GetSection("EducationDatabaseAddress").Value;
                optionsBuilder.UseNpgsql(orbitaStringConnection);
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
                base.OnConfiguring(optionsBuilder);
            }
        }      
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddMappings();
        }        
        
    }
}