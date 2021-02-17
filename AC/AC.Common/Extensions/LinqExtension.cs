using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AC.ViewModels;

namespace AC.Common.Extensions
{
    public static class LinqExtension
    {
        public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query, int page = 1, int pageSize = 10) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = await query.CountAsync();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Collection = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
