using System.Threading;
using System.Threading.Tasks;
using Kasp.Db.Helpers;
using Kasp.Identity.Entities.UserEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Identity {
	public class KIdentityDbContext<TUser, TRole> : IdentityDbContext<TUser, TRole, int> where TUser : KaspUser where TRole : KaspRole {
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
}