using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.HelperClasses
{
    public class PaginatedList<T>: List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int PageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IList<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count(); //EntityFrameworkcore
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(); // not async, problem with Iquarable
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
