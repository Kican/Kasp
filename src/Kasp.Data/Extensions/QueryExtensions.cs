using System.Linq;
using System.Linq.Dynamic.Core;
using Kasp.Data.Models;

namespace Kasp.Data.Extensions {
	public static class QueryExtensions {
		public static IQueryable<T> SortBy<T>(this IQueryable<T> queryable, FilterBase filter) {
			if (!string.IsNullOrEmpty(filter.OrderBy))
				queryable = queryable.OrderBy(filter.OrderBy + " " + (filter.IsDesc ? "desc" : ""));

			return queryable;
		}
	}
}