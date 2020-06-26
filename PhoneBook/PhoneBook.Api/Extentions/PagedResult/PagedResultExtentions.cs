using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Extentions.PagedResult
{
    public static class PagedResultExtentions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class, new()
        {
            var result = new PagedResult<T>();
            result.Count = query.Count();

            var skip = (page - 1) * pageSize;
            result.Data = query.Skip(skip).Take(pageSize).AsEnumerable();

            return result;
        }
    }
}
