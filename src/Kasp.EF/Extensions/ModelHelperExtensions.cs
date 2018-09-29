using System;
using System.Linq;
using Kasp.EF.Models.Helpers;

namespace Kasp.EF.Extensions {
	public static class ModelHelperExtensions {
		private static IQueryable<T> _enableFilter<T>(this IQueryable<T> queryable) => queryable.Where(x => (x as IEnable).Enable);
		public static IQueryable<T> EnableFilter<T>(this IQueryable<T> queryable) where T : IEnable => queryable._enableFilter();

		private static IQueryable<T> _priorityFilter<T>(this IQueryable<T> queryable) => queryable.OrderByDescending(x => (x as IPriority).Priority);
		public static IQueryable<T> PriorityFilter<T>(this IQueryable<T> queryable) where T : IPriority => queryable._priorityFilter();
		public static IQueryable<T> PriorityAscFilter<T>(this IQueryable<T> queryable) where T : IPriority => queryable._priorityFilter();

		private static IQueryable<T> _publishTimeFilter<T>(this IQueryable<T> queryable) {
			var now = DateTime.UtcNow;
			return queryable.Where(x => (x as IPublishTime).PublishTime <= now);
		}

		public static IQueryable<T> PublishTimeFilter<T>(this IQueryable<T> queryable) where T : IPublishTime => queryable._publishTimeFilter();

		private static IQueryable<T> _softDeleteFilter<T>(this IQueryable<T> queryable) => queryable.Where(x => (x as ISoftDelete).SoftDelete == null);
		public static IQueryable<T> SoftDeleteFilter<T>(this IQueryable<T> queryable) where T : ISoftDelete => queryable._softDeleteFilter();
		public static IQueryable<T> JustSoftDeleteFilter<T>(this IQueryable<T> queryable) where T : ISoftDelete => queryable.Where(x => x.SoftDelete != null);


		public static IQueryable<T> AllFilters<T>(this IQueryable<T> queryable) {
			if (typeof(IEnable).IsAssignableFrom(typeof(T))) queryable = queryable._enableFilter();

			if (typeof(IPublishTime).IsAssignableFrom(typeof(T))) queryable = queryable._publishTimeFilter();

			if (typeof(ISoftDelete).IsAssignableFrom(typeof(T))) queryable = queryable._softDeleteFilter();

			if (typeof(IPriority).IsAssignableFrom(typeof(T))) queryable = queryable._priorityFilter();

			return queryable;
		}
	}
}