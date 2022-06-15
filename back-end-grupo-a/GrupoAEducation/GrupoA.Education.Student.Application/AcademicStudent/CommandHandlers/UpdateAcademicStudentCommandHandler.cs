using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrupoA.Education.Student.Application.AcademicStudent.Command;
using GrupoA.Education.Student.Application.AcademicStudent.generic;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;
using GrupoA.Education.Student.Application.Resources;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Domain.Interfaces;
using GrupoA.Education.Student.Infra.Data.Uow;
using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.CommandHandlers
{
    public class UpdateAcademicStudentCommandHandler: IRequestHandler<UpdateAcademicStudentCommand, CommandResult<AcademicStudentViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly INotificationContext _notificationContext;
        private readonly IAcademicStudentService _academicStudentService;

        public UpdateAcademicStudentCommandHandler(IUnitOfWork uow, IMapper mapper, INotificationContext notificationContext, IAcademicStudentService academicStudentService)
        {
            _uow = uow;
            _mapper = mapper;
            _notificationContext = notificationContext;
            _academicStudentService = academicStudentService;
        }

        public async Task<CommandResult<AcademicStudentViewModel>> Handle(UpdateAcademicStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _uow.Students.GetById(request.PrimaryKey);
            if (student == null)
            {
                _notificationContext.NotFound(nameof(Messages.StudentNotFound), 
                    string.Format(Messages.StudentNotFound, request.PrimaryKey.ToString()));
                return new CommandResult<AcademicStudentViewModel>();
            }

            await ValidateUpdateAcademicStudent(request);
            if (_notificationContext.ExistsNotifications())
                return new CommandResult<AcademicStudentViewModel>();
            
            UpdateStudentInformations(student, request);
            
            if (await _uow.Commit())
                return new CommandResult<AcademicStudentViewModel>(true, _mapper.Map<AcademicStudentViewModel>(student));

            _notificationContext.BadRequest(nameof(Messages.ErrorOnUpdate), 
                string.Format(Messages.ErrorOnUpdate, "student", request.PrimaryKey.ToString()));
            
            return new CommandResult<AcademicStudentViewModel>();            
        }

        private async Task ValidateUpdateAcademicStudent(UpdateAcademicStudentCommand request)
        {
            await _academicStudentService.AnotherStudenAlreadyExists(request.Ra, request.Itin, request.Mail, request.PrimaryKey);
            
            Regex onlyNumbersRegex = new Regex(@"(?i)[^0-9]");
            var onlyNumbersItin = onlyNumbersRegex.Replace(request.Itin, string.Empty);

            if (!_academicStudentService.IsBrazilianItinValid(onlyNumbersItin))
                _notificationContext.BadRequest(nameof(Messages.CpfIsNotValid), 
                    string.Format(Messages.CpfIsNotValid, request.Itin));            
        }

        private void UpdateStudentInformations(Domain.Student.Entities.Student student, UpdateAcademicStudentCommand request)
        {
            student.Name = request.Name;
            student.Mail = request.Mail.ToLower();
            student.Itin = request.Itin;
            student.Ra = request.Ra;
            
            _uow.Students.Update(student);
        }
    }
}