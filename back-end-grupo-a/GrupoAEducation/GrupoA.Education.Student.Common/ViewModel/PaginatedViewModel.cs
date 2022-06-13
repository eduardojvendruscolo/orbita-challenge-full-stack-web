using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GrupoA.Education.Student.Common.ViewModel
{
    public class PaginatedViewModel<T>
    {
        public ICollection<T> Records { get; set; }
        public int Page { get; }
        public int PageCount { get; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }

        public PaginatedViewModel(ICollection<T> records, int page, int pageCount, int totalRecords, int totalPages)
        {
            Records = records ?? new Collection<T>();
            Page = page;
            PageCount = pageCount;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
        }        
    }
}