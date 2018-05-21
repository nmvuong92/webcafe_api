using System;
using System.Linq;
using System.Linq.Expressions;

namespace VD.Data.Base
{
    public static class LinqHelpers
    { 
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Ascending ? "OrderBy" : "OrderByDescending";
            var types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }

        public static IQueryable<T> FilterByField<T>(this IQueryable<T> q, string FilterField)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, FilterField);
            var exp = Expression.Lambda(prop, param);
            const string method = "Contain";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
    }
}
