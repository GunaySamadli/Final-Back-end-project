using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class PagenatedList<T> : List<T>
    {
        public PagenatedList(List<T> items, int count, int pageSize, int pageIndex)
        {
            this.AddRange(items);

            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public bool HasPrev
        {
            get
            {
                return PageIndex > 1;
            }
        }
        public bool HasNext
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }

        public static PagenatedList<T> Create(IQueryable<T> query, int pageSize, int pageIndex)
        {
            var items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagenatedList<T>(items, query.Count(), pageSize, pageIndex);
        }
    }
}
