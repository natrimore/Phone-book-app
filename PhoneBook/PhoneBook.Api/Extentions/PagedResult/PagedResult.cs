using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Extentions.PagedResult
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Count { get; set; }
    }
}
