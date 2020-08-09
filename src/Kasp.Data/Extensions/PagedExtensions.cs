using System.Linq;

namespace Kasp.Data.Extensions {
	public static class PagedExtensions {
		public static PagedResult<T> ToPagedResult<T>(this IPagedList<T> list) {
			return new PagedResult<T> {Items = list.ToArray(), TotalCount = list.TotalCount};
		}
	}
}