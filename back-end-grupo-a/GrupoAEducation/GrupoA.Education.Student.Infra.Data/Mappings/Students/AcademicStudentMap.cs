using GrupoA.Education.Student.Infra.Data.DataDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoA.Education.Student.Infra.Data.Mappings.Students
{
    public class AcademicStudentMap: IEntityTypeConfiguration<Domain.Student.Entities.Student>
    {
        public void Configure(EntityTypeBuilder<Domain.Student.Entities.Student> builder)
        {
            builder
                .ToTable(nameof(Student));
            
            builder
                .Property(m => m.Itin)
                .HasColumnType(DatabaseTypes.String(11))
                .IsRequired();

            builder
                .Property(m => m.Ra)
                .HasColumnType(DatabaseTypes.Integer)
                .IsRequired();            

            builder
                .Property(m => m.PrimaryKey)
                .HasColumnType(DatabaseTypes.Uuid)
                .IsRequired();

            builder
                .Property(m => m.Name)
                .HasColumnType(DatabaseTypes.String())
                .IsRequired();

            builder
                .Property(m => m.Mail)
                .HasColumnType(DatabaseTypes.String())
                .IsRequired();

            builder
                .HasIndex(x => x.Ra)
                .IsUnique();

            builder.HasIndex(x => new {x.Itin, x.Mail, x.Name, x.Ra });
        }
    }
}