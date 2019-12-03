using System.Threading;
using System.Threading.Tasks;
using Kasp.Data.EF.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Data.EF {
	public class KDbContext<TDbContext> : DbContext where TDbContext : KDbContext<TDbContext> {
		public KDbContext(DbContextOptions<TDbContext> options) : base(options) {
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

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

//			foreach (var entityType in Model.GetEntityTypes()) {
//				EntityHelperFactory.GetQueryFilter(entityType.ClrType).ForEach(helper =>  modelBuilder.Entity(entityType.ClrType).HasQueryFilter(helper.QueryFilter<IEnable>()) );
//			}
		}

//		public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> expression) {
//			var entities = modelBuilder.Model
//				.GetEntityTypes()
//				.Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
//				.Select(e => e.ClrType);
//			foreach (var entity in entities) {
//				var newParam = Expression.Parameter(entity);
//				var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
//				modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
//			}
//		}
	}
}