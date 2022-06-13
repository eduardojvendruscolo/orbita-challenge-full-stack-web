using System.Linq;
using GrupoA.Education.Student.Domain.Interfaces;

namespace GrupoA.Education.Student.Domain.Student.Interfaces
{
    public interface IStudentRepository : IRepository<Entities.Student>
    {
        IQueryable<Entities.Student> GetAll(string filter, string orderByField, string orderType);
    }
}