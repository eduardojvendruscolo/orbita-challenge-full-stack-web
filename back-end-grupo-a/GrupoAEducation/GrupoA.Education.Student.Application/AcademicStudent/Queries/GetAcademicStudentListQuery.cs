using GrupoA.Education.Student.Application.AcademicStudent.generic;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;
using GrupoA.Education.Student.Common.ViewModel;

namespace GrupoA.Education.Student.Application.AcademicStudent.Queries
{
    public class GetAcademicStudentListQuery : PaginatedQuery<PaginatedViewModel<AcademicStudentViewModel>>
    {
        public GetAcademicStudentListQuery(string filter, int pageSize, int pageOffset, string orderByField, string orderType) : base(filter, pageSize, pageOffset, orderByField, orderType)
        {
        }
    }
}