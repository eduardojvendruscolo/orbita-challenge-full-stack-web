using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GrupoA.Education.Student.Common.ViewModel;
using GrupoA.Education.Student.Domain.Generic.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrupoA.Education.Student.Infra.Data.Extensions
{
    public static class PaginatedListExtension
    {
        public static async Task<PaginatedViewModel<TViewModel>> PaginateAsync<TEntity, TViewModel>(
            this IQueryable<TEntity> query, IMapper mapper, int page = 1, int pageCount = 20, CancellationToken cancellationToken = default) where TEntity : BaseEntity
        {
            if (page <= 0) 
                page = 1;
            
            var skipRecordsCount = (page - 1) * pageCount;
            var totalRecords = await query.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalRecords / (decimal) pageCount);

            var list = await
                query.Skip(skipRecordsCount)
                    .Take(pageCount)
                    .ProjectTo<TViewModel>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new PaginatedViewModel<TViewModel>(list, page, pageCount, totalRecords, totalPages);
        }        
    }
}