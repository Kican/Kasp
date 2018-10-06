using Kasp.Core.Extensions;
using Kasp.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Test.EF.Extensions {
	public static class AppBuilderExtensions {
		public static KaspDbAppBuilder UseTestDataBase<TDbContext>(this KaspAppBuilder builder) where TDbContext : DbContext {
			var db = builder.ApplicationBuilder.ApplicationServices.GetService<TDbContext>();

			db.Database.EnsureDeleted();
			db.Database.EnsureCreated();

			return builder.UseDataBase<TDbContext>();
		}
	}
}