using System.Linq;

namespace Kasp.Data {
	public class PagedResult<T> {
		public int TotalCount { get; set; }
		public T[] Items { get; set; }
	}

	public static class PagedResultExtensions {
		public static PagedResult<T> ToPagedResult<T>(this IPagedList<T> collection) where T : class {
			return new PagedResult<T> {
				Items = collection.ToArray(),
				TotalCount = collection.TotalCount
			};
		}
	}
}