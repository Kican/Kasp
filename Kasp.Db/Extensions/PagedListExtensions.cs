using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasp.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Extensions {
	public static class PagedListExtensions {
		public static bool IsFirstPage(this IPagedList pagedList) => pagedList.PageIndex == 1;

		public static bool IsLastPage(this IPagedList pagedList) => pagedList.PageIndex == pagedList.TotalPage;

		public static Task<PagedList<IQueryable<T>, T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageSize, int pageIndex = 1) {
			return CreatePagedListCoreAsync(source, pageSize, pageIndex, (data, skip, take) => data.Skip(skip).Take(take).ToArrayAsync(), data => data.CountAsync());
		}

		public static PagedList<IEnumerable<T>, T> ToPagedList<T>(this IEnumerable<T> source, int pageSize, int pageIndex = 1) {
			return CreatePagedListCore(source, pageSize, pageIndex, (data, skip, take) => data.Skip(skip).Take(take).ToArray(), data => data.Count());
		}


		public static PagedList<IQueryable<T>, T> ToPagedList<T>(this IQueryable<T> source, int pageSize, int pageIndex = 1) {
			return CreatePagedListCore(source, pageSize, pageIndex, (data, skip, take) => data.Skip(skip).Take(take).ToArray(), data => data.Count());
		}

		private static PagedList<TSource, TElement> CreatePagedListCore<TSource, TElement>(this TSource source, int pageSize, int pageIndex, Func<TSource, int, int, IList<TElement>> pageFunc, Func<TSource, int> countFunc) {
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (pageSize <= 0)
				throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "The page size must be positive.");

			if (pageIndex <= 0)
				throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, "The page index must be positive.");

			var skipValue = pageSize * (pageIndex - 1);
			var takeValue = pageSize;

			var currentPage = pageFunc(source, skipValue, takeValue);
			var totalCount = countFunc(source);
			var totalPage = (totalCount - 1) / pageSize + 1;

			return new PagedList<TSource, TElement>(currentPage, source, pageSize, pageIndex, totalCount, totalPage);
		}

		private static async Task<PagedList<TSource, TElement>> CreatePagedListCoreAsync<TSource, TElement>(this TSource source, int pageSize, int pageIndex, Func<TSource, int, int, Task<TElement[]>> pageFunc, Func<TSource, Task<int>> countFunc) {
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (pageSize <= 0)
				throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "The page size must be positive.");

			if (pageIndex <= 0)
				throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, "The page index must be positive.");

			var skipValue = pageSize * (pageIndex - 1);
			var takeValue = pageSize;

			var currentPage = await pageFunc(source, skipValue, takeValue);
			var totalCount = await countFunc(source);
			var totalPage = (totalCount - 1) / pageSize + 1;

			return new PagedList<TSource, TElement>(currentPage, source, pageSize, pageIndex, totalCount, totalPage);
		}
	}
}