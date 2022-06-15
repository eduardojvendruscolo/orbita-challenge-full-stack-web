using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrupoA.Education.Student.Application.AcademicStudent.Command;
using GrupoA.Education.Student.Application.AcademicStudent.generic;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Domain.Interfaces;
using GrupoA.Education.Student.Infra.Data.Uow;
using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.CommandHandlers
{
    public class InsertAcademicStudentCommandHandler: IRequestHandler<InsertAcademicStudentCommand, CommandResult<AcademicStudentViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly INotificationContext _notificationContext;
        private readonly IAcademicStudentService _academicStudentService;

        public InsertAcademicStudentCommandHandler(IUnitOfWork uow, IMapper mapper, INotificationContext notificationContext, IAcademicStudentService academicStudentService)
        {
            _uow = uow;
            _mapper = mapper;
            _notificationContext = notificationContext;
            _academicStudentService = academicStudentService;
        }

        public async Task<CommandResult<AcademicStudentViewModel>> Handle(InsertAcademicStudentCommand request, CancellationToken cancellationToken)
        {
            var newAcademicStudent = _mapper.Map<Domain.Student.Entities.Student>(request);
            newAcademicStudent.Mail = newAcademicStudent.Mail.ToLower();
            
            Regex onlyNumbersRegex = new Regex(@"(?i)[^0-9]");
            newAcademicStudent.Itin = onlyNumbersRegex.Replace(newAcademicStudent.Itin, string.Empty);
            
            await ValidateInsertNewAcademicStudent(request);

            if (_notificationContext.ExistsNotifications())
                return new CommandResult<AcademicStudentViewModel>();

            newAcademicStudent.Ra = _uow.Students.GetNextRaNumber();
            await _uow.Students.Add(newAcademicStudent);
            
            if (await _uow.Commit())
                return new CommandResult<AcademicStudentViewModel>(true, _mapper.Map<AcademicStudentViewModel>(newAcademicStudent));            
            
            _notificationContext.BadRequest(nameof(Messages.Messages.ErrorOnCommit), 
                string.Format(Messages.Messages.ErrorOnCommit, "new student"));
            return new CommandResult<AcademicStudentViewModel>();
        }

        private async Task ValidateInsertNewAcademicStudent(InsertAcademicStudentCommand request)
        {
            await _academicStudentService.AcademicStudenAlreadyExists(request.Ra, request.Itin, request.Mail);
            
            Regex onlyNumbersRegex = new Regex(@"(?i)[^0-9]");
            var onlyNumbersItin = onlyNumbersRegex.Replace(request.Itin, string.Empty);

            if (!_academicStudentService.IsBrazilianItinValid(onlyNumbersItin))
                _notificationContext.BadRequest(nameof(Messages.Messages.CpfIsNotValid), 
                    string.Format(Messages.Messages.CpfIsNotValid, request.Itin));
        }
    }
}