using PagedList.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PagedList.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Converts the passed generic List to a PagedList
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">List to invoke this extension method on</param>
        /// <param name="pageNo">Current page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> list, int pageNumber, int pageSize)
        {
            PagedList<T> pagedList = new PagedList<T>(list, pageNumber, pageSize);
            return pagedList;
        }

        /// <summary>
        /// Converts the passed generic List to a PagedList
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">List to invoke this extension method on</param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> list)
        {
            PagedList<T> pagedList = new PagedList<T>(list);
            return pagedList;
        }
    }
}