using System;
using System.Threading.Tasks;
using GrupoA.Education.Student.Domain.Student.Interfaces;

namespace GrupoA.Education.Student.Infra.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        Task<bool> Commit();
    }
}