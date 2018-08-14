using System;
using Kasp.Db.Extensions;
using Kasp.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kasp.Db.Helpers {
	public class EntityModifier {
		public static void Use(ChangeTracker changeTracker) {
			var now = DateTime.UtcNow;

			foreach (var entry in changeTracker.Entries()) {
//				if (entry.Entity is IModelChangeNotify)
//					((IModelChangeNotify) entry.Entity).OnModified(this, entry.State);

				if (entry.State == EntityState.Added) {
					if (entry.Entity is ICreateTime)
						((ICreateTime) entry.Entity).Create();

//					if (entry.Entity is IUpdateTime)
//						((IUpdateTime) entry.Entity).UpdateTime = now;
				}

				if (entry.State == EntityState.Modified)
					if (entry.Entity is IUpdateTime)
						((IUpdateTime) entry.Entity).Update();

				if (entry.State == EntityState.Deleted)
					if (entry.Entity is ISoftDelete)
						((ISoftDelete) entry.Entity).SoftDelete();
			}
		}
	}
}