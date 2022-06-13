using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrupoA.Education.Student.Application.AcademicStudent.Queries;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;
using GrupoA.Education.Student.Common.ViewModel;
using GrupoA.Education.Student.Infra.Data.Extensions;
using GrupoA.Education.Student.Infra.Data.Uow;
using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.QueryHandlers
{
    public class GetAcademicStudentListQueryHandler : IRequestHandler<GetAcademicStudentListQuery, PaginatedViewModel<AcademicStudentViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAcademicStudentListQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }        
        
        public async Task<PaginatedViewModel<AcademicStudentViewModel>> Handle(GetAcademicStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _uow.Students.GetAll(request.Filter, request.OrderByField, request.OrderType)
                .PaginateAsync<Domain.Student.Entities.Student, AcademicStudentViewModel>(_mapper, request.PageOffset, request.PageSize, cancellationToken);
        }
    }
}