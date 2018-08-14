using System.Threading;
using System.Threading.Tasks;
using Kasp.Db.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db {
	public class KDbContext<TDbContext> : DbContext where TDbContext : KDbContext<TDbContext> {
		public KDbContext(DbContextOptions<TDbContext> options) : base(options) { }

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