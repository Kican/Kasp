using Kasp.Data.EF;
using Kasp.Localization.EF.Data;
using Kasp.Localization.EF.Models;
using Kasp.Localization.EF.Tests.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Localization.EF.Tests.Data {
	public class LocalizationDbContext : KDbContext<LocalizationDbContext>, ILocalizationDbContext {
		public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options) : base(options) {
		}

		public DbSet<Lang> Langs { get; set; }
		public DbSet<Post> Posts { get; set; }
	}
}