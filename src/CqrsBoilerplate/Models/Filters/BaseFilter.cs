using System;
using System.Reflection;

namespace CqrsBoilerplate.Models.Filters
{
    public class BaseFilter
    {
        protected BaseFilter()
        {
            TotalItemCountRequired = true;
        }

        public int CurrentPage { get; set; }

        public int? PageSize { get; set; }

        public int? TotalItemsCount { get; set; }

        public string SortedBy { get; set; }

        public string SortDir { get; set; }

        public bool TotalItemCountRequired { get; set; }

        
    }

    public abstract class BaseFilter<TEnum> : BaseFilter
    {
        static BaseFilter()
        {
            Type type = typeof(TEnum);

            if (!type.GetTypeInfo().IsEnum)
                throw new Exception($"Type '{type.FullName}' must be enum");
        }

        public TEnum Scope { get; set; }
    }
}
