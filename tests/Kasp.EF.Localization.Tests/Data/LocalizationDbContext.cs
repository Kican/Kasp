using Kasp.EF.Localization.Data;
using Kasp.EF.Localization.Models;
using Kasp.EF.Localization.Tests.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.EF.Localization.Tests.Data {
	public class LocalizationDbContext : KDbContext<LocalizationDbContext>, ILocalizationDbContext {
		public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options) : base(options) {
		}

		public DbSet<Lang> Langs { get; set; }
		public DbSet<Post> Posts { get; set; }
	}
}