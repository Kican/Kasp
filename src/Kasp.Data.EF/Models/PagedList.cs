using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kasp.Data.EF.Models {
	public class PagedList<TSource, TElement> : IPagedList<TElement> {
		public PagedList(IList<TElement> currentPage, TSource source, int pageSize, int pageIndex,
			int totalCount, int totalPage) {
			if (currentPage == null)
				throw new ArgumentNullException(nameof(currentPage));

			if (pageSize <= 0)
				throw new ArgumentOutOfRangeException(nameof(pageSize));

			if (pageIndex <= 0)
				throw new ArgumentOutOfRangeException(nameof(pageIndex));

			if (totalCount < 0)
				throw new ArgumentOutOfRangeException(nameof(totalCount));

			if (totalPage < 0)
				throw new ArgumentOutOfRangeException(nameof(totalPage));

			Source = source != null ? source : throw new ArgumentNullException(nameof(source));
			PageSize = pageSize;
			PageIndex = pageIndex;
			CurrentPage = new ReadOnlyCollection<TElement>(currentPage);
			TotalCount = totalCount;
			TotalPage = totalPage;
		}


		protected ReadOnlyCollection<TElement> CurrentPage { get; }


		public TSource Source { get; }


		public int PageSize { get; }


		public int PageIndex { get; }

		public int TotalCount { get; }

		public int TotalPage { get; }

		public int Count => CurrentPage.Count;

		public TElement this[int index] => CurrentPage[index];

		IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator() {
			return CurrentPage.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable) CurrentPage).GetEnumerator();
		}

		void ICollection.CopyTo(Array array, int index) {
			((ICollection) CurrentPage).CopyTo(array, index);
		}

		bool ICollection.IsSynchronized => ((ICollection) CurrentPage).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection) CurrentPage).SyncRoot;

		/// <inheritdoc />
		int IList.Add(object value) {
			throw new NotSupportedException();
		}

		/// <inheritdoc />
		void IList.Clear() {
			throw new NotSupportedException();
		}


		/// <inheritdoc />
		bool IList.Contains(object value) {
			return ((IList) CurrentPage).Contains(value);
		}


		/// <inheritdoc />
		int IList.IndexOf(object value) {
			return ((IList) CurrentPage).IndexOf(value);
		}


		/// <inheritdoc />
		void IList.Insert(int index, object value) {
			throw new NotSupportedException();
		}

		/// <inheritdoc />
		void IList.Remove(object value) {
			throw new NotSupportedException();
		}

		/// <inheritdoc />
		void IList.RemoveAt(int index) {
			throw new NotSupportedException();
		}

		/// <inheritdoc />
		bool IList.IsFixedSize => true;

		/// <inheritdoc />
		bool IList.IsReadOnly => true;

		/// <inheritdoc />
		object IList.this[int index] {
			get => ((IList) CurrentPage)[index];
			set => throw new NotSupportedException();
		}
	}
}