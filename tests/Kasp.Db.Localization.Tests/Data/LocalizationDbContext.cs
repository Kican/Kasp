using Kasp.Db.Localization.Data;
using Kasp.Db.Localization.Models;
using Microsoft.EntityFrameworkCore;

namespace Kasp.Db.Localization.Tests.Data {
	public class LocalizationDbContext : KDbContext<LocalizationDbContext>, ILocalizationDbContext {
		public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options) : base(options) {
		}

		public DbSet<Lang> Langs { get; set; }
	}
}