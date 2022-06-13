using System;
using System.Threading.Tasks;

namespace GrupoA.Education.Student.Domain.Interfaces
{
    public interface IAcademicStudentService
    {
        Task AcademicStudenAlreadyExists(int ra, string itin, string mail);
        Task AnotherStudenAlreadyExists(int ra, string itin, string mail, Guid primaryKey);
        bool IsBrazilianItinValid(string Itin);
    }
}