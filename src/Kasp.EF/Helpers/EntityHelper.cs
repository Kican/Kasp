using System;
using System.Linq;
using Kasp.EF.Extensions;
using Kasp.EF.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kasp.EF.Helpers {
	public interface IEntityHelper {
		bool IsGlobalFilter { get; }
		IQueryable<T> QueryFilter<T>(IQueryable<T> queryable);
		void EntityModifier(ChangeTracker tracker);
	}

	public abstract class EntityHelper<THelper> : IEntityHelper {
		public virtual bool IsGlobalFilter { get; } = false;

		// filter
		public virtual IQueryable<T> QueryFilter<T>(IQueryable<T> queryable) {
			return queryable;
		}
		// model builder

		// entity modifier
		public virtual void EntityModifier(ChangeTracker tracker) {
		}
	}

	public class EnableEntityHelper : EntityHelper<IEnable> {
		public override IQueryable<T> QueryFilter<T>(IQueryable<T> queryable) => queryable.Where(x => (x as IEnable).Enable);
	}
	public class PublishEntityHelper : EntityHelper<IPublishTime> {
		public override IQueryable<T> QueryFilter<T>(IQueryable<T> queryable) {
			var now = DateTime.UtcNow;
			return queryable.Where(x => (x as IPublishTime).PublishTime <= now);
		}
	}

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