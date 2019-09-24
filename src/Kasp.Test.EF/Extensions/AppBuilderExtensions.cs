using Kasp.Core.Extensions;
using Kasp.Data.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kasp.Test.EF.Extensions {
	public static class AppBuilderExtensions {
		public static void UseTestDataBase<TDbContext>(this KaspAppBuilder builder) where TDbContext : DbContext {
			var db = builder.ApplicationBuilder.ApplicationServices.GetService<TDbContext>();

			db.Database.EnsureDeleted();
			db.Database.EnsureCreated();
		}
	}
}