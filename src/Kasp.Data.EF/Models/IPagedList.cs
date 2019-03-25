using System.Collections;
using System.Collections.Generic;

namespace Kasp.Data.EF.Models {
	public interface IPagedList : IList {
		int PageIndex { get; }

		int PageSize { get; }

		int TotalPage { get; }

		int TotalCount { get; }
	}

	public interface IPagedList<out T> : IPagedList, IReadOnlyList<T> {
		new int Count { get; }

		new T this[int index] { get; }
	}
}