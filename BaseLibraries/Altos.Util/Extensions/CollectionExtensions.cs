using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using Altos.Util.Application.Dto;

namespace Altos.Util.Extensions
{
    /// <summary>
    /// Extension methods for Dictionary.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks whatever given collection object is null or has no item.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        /// <summary>
        /// Distinct, sort and remove nulls (or zero's for integers) from list.
        /// </summary>
        public static List<T> DistinctSort<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return new List<T>();

            // distinct
            var sourceToReturn = source.Distinct().ToList();

            // remove null or zero integers
            sourceToReturn.RemoveAll(o => o == null || o is int i && i == 0);

            // sort
            sourceToReturn.Sort();

            return sourceToReturn;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate and condition.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        /// <Summary>
        /// Sorts the specified data collection using the specified sort direction.
        /// </Summary>
        /// <param name="source">The source.</param>
        /// <param name="request">Sort request information.</param>
        /// <returns>The ordered collection</returns>
        public static IQueryable<TEntity> GetSortedQuery<TEntity>(this IQueryable<TEntity> source, PagedSortedRequest request)
        {
            if (request == null)
                return source;
            if (request.SortProperty.IsNullOrEmpty() || !request.SortDirection.HasValue)
                return source;

            return source.OrderBy($"{request.SortProperty} {request.SortDirection}");
        }

        /// <summary>
        /// Sorts and pages the specified data collection using the specified request data.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> FromPagedSortedRequest<TEntity>(this IQueryable<TEntity> source, PagedSortedRequest request)
        {
            source = source.GetSortedQuery(request);
            source = source.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            return source;
        }
    }
}
