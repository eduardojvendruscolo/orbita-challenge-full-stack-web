using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.generic
{
    public class PaginatedQuery<TResponse> : IRequest<TResponse>
    {
        public string Filter { get; set; }
        public int PageSize { get; set; }
        public int PageOffset { get; set; }
        public string OrderByField { get; set; }
        public string OrderType { get; set; }

        protected PaginatedQuery(string filter, int pageSize, int pageOffset, string orderByField, string orderType)
        {
            Filter = filter;
            PageSize = pageSize;
            PageOffset = pageOffset;
            OrderByField = orderByField;
            OrderType = orderType;
        }
    }
}