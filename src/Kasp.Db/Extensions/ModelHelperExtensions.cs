using System;
using System.Linq;
using Kasp.Db.Models.Helpers;

namespace Kasp.Db.Extensions {
	public static class ModelHelperExtensions {
		public static IQueryable<T> EnableFilter<T>(this IQueryable<T> queryable) where T : IEnable => queryable.Where(x => x.Enable);

		public static IQueryable<T> PriorityFilter<T>(this IQueryable<T> queryable) where T : IPriority => queryable.OrderByDescending(x => x.Priority);
		public static IQueryable<T> PriorityAscFilter<T>(this IQueryable<T> queryable) where T : IPriority => queryable.OrderBy(x => x.Priority);

		public static IQueryable<T> PublishTimeFilter<T>(this IQueryable<T> queryable) where T : IPublishTime {
			var now = DateTime.Now;
			return queryable.Where(x => x.PublishTime != null || x.PublishTime <= now);
		}

		public static IQueryable<T> SoftDeleteFilter<T>(this IQueryable<T> queryable) where T : ISoftDelete => queryable.Where(x => x.SoftDelete == null);
		public static IQueryable<T> JustSoftDeleteFilter<T>(this IQueryable<T> queryable) where T : ISoftDelete => queryable.Where(x => x.SoftDelete != null);


		public static IQueryable<T> AllFilters<T>(this IQueryable<T> queryable) {
			if (typeof(IEnable).IsAssignableFrom(typeof(T))) (queryable as IQueryable<IEnable>).EnableFilter();
			if (typeof(IPublishTime).IsAssignableFrom(typeof(T))) (queryable as IQueryable<IPublishTime>).PublishTimeFilter();
			if (typeof(ISoftDelete).IsAssignableFrom(typeof(T))) (queryable as IQueryable<ISoftDelete>).SoftDeleteFilter();


			if (typeof(IPriority).IsAssignableFrom(typeof(T))) (queryable as IQueryable<IPriority>).PriorityFilter();

			return queryable;
		}
	}
}