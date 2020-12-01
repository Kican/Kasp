using Kasp.Data.EF.Extensions;
using Kasp.Data.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kasp.Data.EF.Helpers {
// https://stackoverflow.com/questions/29261734/add-filter-to-all-query-entity-framework
// https://gist.github.com/nphmuller/05ff66dfa67e1d02cdefcd785661a34d
	public interface IEntityHelper {
//		Expression<Func<T, bool>> QueryFilter<T>();
		void EntityModifier(ChangeTracker tracker);
	}


	public abstract class EntityHelper<THelper> : IEntityHelper {
		// filter
//		public virtual Expression<Func<THelper, bool>> QueryFilter() {
//			return arg => true;
//		}

		// entity modifier

		public virtual void EntityModifier(ChangeTracker tracker) {
		}
	}

//	public class EnableEntityHelper : EntityHelper<IEnable> {
////		public override IQueryable<T> QueryFilter<T>(IQueryable<T> queryable) {
////			if (typeof(IEnable).IsAssignableFrom(typeof(T))) {
////				queryable = (IQueryable<T>) (queryable as IQueryable<IEnable>).EnableFilter();
////			}
////
////			LambdaExpression x = Expression.Lambda(queryable.Expression);
////
////			return queryable;
////		}
////		public override Expression<Func<T, bool>> QueryFilter<T>() => x => x.Enable;
//	}

//	public class PublishEntityHelper : EntityHelper<IPublishTime> {
////		public override IQueryable<T> QueryFilter<T>(IQueryable<T> queryable) {
////			var now = DateTime.UtcNow;
////			return queryable.Where(x => (x as IPublishTime).PublishTime <= now);
////		}
//	}

	public class CreateTimeEntityHelper : EntityHelper<ICreateTime> {
		public override void EntityModifier(ChangeTracker tracker) {
			foreach (var entityEntry in tracker.Entries()) {
				if (entityEntry.State != EntityState.Added) continue;
				(entityEntry.Entity as ICreateTime)?.Create();
			}
		}
	}

	public class UpdateTimeEntityHelper : EntityHelper<IUpdateTime> {
		public override void EntityModifier(ChangeTracker tracker) {
			foreach (var entityEntry in tracker.Entries()) {
				if (entityEntry.State != EntityState.Modified) continue;
				if (entityEntry.Entity is IUpdateTime time)
					time.Update();
			}
		}
	}
}
