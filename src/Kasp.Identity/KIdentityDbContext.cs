using System;
using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Helpers;
using Kasp.Identity.Core.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Identity {
	public class KIdentityDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey> where TUser : IdentityUser<TKey> where TRole : KaspRole<TKey> where TKey : unmanaged, IEquatable<TKey> {
		public KIdentityDbContext(DbContextOptions options) : base(options) {
		}

		public override int SaveChanges() {
			TrackerTrigger();
			return base.SaveChanges();
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess) {
			TrackerTrigger();
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
			TrackerTrigger();
			return base.SaveChangesAsync(cancellationToken);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken()) {
			TrackerTrigger();
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		protected virtual void TrackerTrigger() {
			EntityModifier.Use(ChangeTracker);
		}
	}

	public class KIdentityDbContext<TUser, TRole> : KIdentityDbContext<TUser, TRole, int> where TRole : KaspRole where TUser : IdentityUser<int> {
		public KIdentityDbContext(DbContextOptions options) : base(options) {
		}
	}
}