using Kasp.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.EF.Extensions {
	public static class AppBuilderExtensions {
		public static KaspDbAppBuilder UseDataBase<TDbContext>(this KaspAppBuilder builder, bool applyMigrates = true) where TDbContext : DbContext {
			var db = builder.ApplicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService<TDbContext>();

			var result = new KaspDbAppBuilder(builder, db);

			if (applyMigrates && !db.Database.IsInMemory())
				db.Database.Migrate();

			return result;
		}
	}

	public class KaspDbAppBuilder : KaspAppBuilder {
		public DbContext Db { get; }


		public KaspDbAppBuilder(KaspAppBuilder appBuilder, DbContext dbContext) : base(appBuilder.ApplicationBuilder) {
			Db = dbContext;
		}
	}
}