using System.Linq;
using CqrsBoilerplate.Models.Filters;

namespace CqrsBoilerplate.Models
{
    public static class Extensions
    {
        public static IQueryable<T> ApplyPageFilter<T>(this IQueryable<T> query, BaseFilter filter)
        {
            var queryOut = query;

            if (filter.PageSize.HasValue)
            {
                var startIndex = (filter.CurrentPage - 1) * filter.PageSize.Value;

                if (startIndex > 0)
                    queryOut = queryOut.Skip(startIndex);
            }

            if (filter.PageSize.HasValue && filter.PageSize.Value > 0)
                queryOut = queryOut.Take(filter.PageSize.Value);

            return queryOut;
        }
    }
}
