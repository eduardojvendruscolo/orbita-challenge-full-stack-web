using System.Threading;
using System.Threading.Tasks;
using GrupoA.Education.Student.Application.AcademicStudent.Command;
using GrupoA.Education.Student.Application.AcademicStudent.generic;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Infra.Data.Uow;
using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.CommandHandlers
{
    public class DeleteAcademicStudentCommandHandler : IRequestHandler<DeleteAcademicStudentCommand, CommandResult<bool>>
    {
        
        private readonly IUnitOfWork _uow;
        private readonly INotificationContext _notificationContext;

        public DeleteAcademicStudentCommandHandler(IUnitOfWork uow, INotificationContext notificationContext)
        {
            _uow = uow;
            _notificationContext = notificationContext;
        }

        public async Task<CommandResult<bool>> Handle(DeleteAcademicStudentCommand request, CancellationToken cancellationToken)
        {
            
            var student = await _uow.Students.GetById(request.PrimaryKey);
            if (student == null)
            {
                _notificationContext.NotFound(
                    nameof(Messages.Messages.StudentNotFound), 
                        string.Format(Messages.Messages.StudentNotFound, request.PrimaryKey.ToString()));
                return new CommandResult<bool>();
            }

            _uow.Students.Delete(student);

            if (await _uow.Commit())
                return new CommandResult<bool>(true, true);

            _notificationContext.BadRequest(
                nameof(Messages.Messages.UnexpectedErrorOn), 
                string.Format(Messages.Messages.UnexpectedErrorOn, "remove student"));
            return new CommandResult<bool>();            
            
        }
    }
}