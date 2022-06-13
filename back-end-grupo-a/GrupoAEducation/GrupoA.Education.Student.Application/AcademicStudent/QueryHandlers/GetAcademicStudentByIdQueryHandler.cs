using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrupoA.Education.Student.Application.AcademicStudent.Queries;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Infra.Data.Uow;
using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.QueryHandlers
{
    public class GetAcademicStudentByIdQueryHandler : IRequestHandler<GetAcademicStudentByIdQuery, AcademicStudentViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly INotificationContext _notificationContext;

        public GetAcademicStudentByIdQueryHandler(IMapper mapper, IUnitOfWork uow, INotificationContext notificationContext)
        {
            _mapper = mapper;
            _uow = uow;
            _notificationContext = notificationContext;
        }

        public async Task<AcademicStudentViewModel> Handle(GetAcademicStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _uow.Students.GetById(request.Id);
            if (student != null)
                return _mapper.Map<AcademicStudentViewModel>(student);

            _notificationContext.NotFound("Student not found", "Student not found");
            return null;
        }
    }
}