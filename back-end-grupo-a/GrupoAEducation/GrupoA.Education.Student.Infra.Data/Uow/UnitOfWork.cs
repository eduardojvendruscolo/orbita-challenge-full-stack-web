using System.Threading.Tasks;
using GrupoA.Education.Student.Domain.Student.Interfaces;
using GrupoA.Education.Student.Infra.Data.Context;
using GrupoA.Education.Student.Infra.Data.Repositories.AcademicStudent;

namespace GrupoA.Education.Student.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationDbContext _educationDbContext;

        private IStudentRepository _students;
        
        public IStudentRepository Students => _students ??= new AcademicStudentRepository(_educationDbContext);

        public UnitOfWork(EducationDbContext educationDbContext)
        {
            _educationDbContext = educationDbContext;
        }

        public async Task<bool> Commit()
        {
            if (!_educationDbContext.ChangeTracker.HasChanges())
                return true;

            return await _educationDbContext.SaveChangesAsync() > 0;
        }
        
        public void Dispose()
        {
            _educationDbContext.Dispose();
        }

    }
}