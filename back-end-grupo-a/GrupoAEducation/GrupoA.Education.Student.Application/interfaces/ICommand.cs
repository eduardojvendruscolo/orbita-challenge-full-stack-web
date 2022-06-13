using GrupoA.Education.Student.Application.AcademicStudent.generic;
using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.interfaces
{
    public interface ICommand<TResponse> : IRequest<CommandResult<TResponse>>
    {

    }
}