using System;
using System.Linq;

namespace CqrsBoilerplate.Models
{
    public class PagedList<T>
    {
        public T[] Items { get; set; }
        public int? PageItemCount { get; set; }
        public int? TotalItemsCount { get; set; }
        public int CurrentPage { get; set; }


        public PagedList<T2> Map<T2>(Func<T, T2> map) where T2 : class
        {
            return new PagedList<T2>
            {
                PageItemCount = PageItemCount,
                CurrentPage = CurrentPage,
                TotalItemsCount = TotalItemsCount,
                Items = Items?.Length > 0 ? Items.Select(map.Invoke).ToArray() : null
            };
        }
    }
}
